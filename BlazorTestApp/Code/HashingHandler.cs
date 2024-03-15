using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Cryptography;
using System.Text;

namespace BlazorTestApp.Code
{
    public class HashingHandler
    {
        [Obsolete]
        public string MDHashing(string textToHash) 
        {
            MD5 md5 = MD5.Create();
            byte[] byteArrayTextToHash = Encoding.ASCII.GetBytes(textToHash);
            byte[] hashedValues = md5.ComputeHash(byteArrayTextToHash);
            return Convert.ToBase64String(hashedValues);
        }

   
        public string SHAHasing(string textToHash) 
        {
            SHA256 md5 = SHA256.Create();
            byte[] byteArrayTextToHash = Encoding.ASCII.GetBytes(textToHash);
            byte[] hashedValues = md5.ComputeHash(byteArrayTextToHash);
            return Convert.ToBase64String(hashedValues);
        }


        public string HMACHasing(string textToHash)
        {
            byte[] byteArrayTextToHash = Encoding.ASCII.GetBytes(textToHash);
            byte[] myKey = Encoding.ASCII.GetBytes("SomeKeyOrIDK");

            HMACSHA256 hmac = new HMACSHA256();
            hmac.Key  = myKey;

            byte[] hashedValues = hmac.ComputeHash(byteArrayTextToHash);

            return Convert.ToBase64String(hashedValues);
        }

        public string PBKDF2Hashing(string textToHash)
        {
            byte[] byteArrayTextToHash = Encoding.ASCII.GetBytes(textToHash);
            byte[] byteArraySalt = Encoding.ASCII.GetBytes("SomeKeyOrIDK");
            var hashingAlgo = new HashAlgorithmName("SHA256");
            int itirationer = 10;

            byte[] hashedValue = Rfc2898DeriveBytes.Pbkdf2(byteArrayTextToHash, byteArraySalt, itirationer, hashingAlgo, 32);

            return Convert.ToBase64String(hashedValue);
        }

        public string BcryptHashing(string textToHash)
        {
            //return BCrypt.Net.BCrypt.HashPassword(textToHash);

            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            return BCrypt.Net.BCrypt.HashPassword(textToHash, salt, true, BCrypt.Net.HashType.SHA256);

            //return BCrypt.Net.BCrypt.HashPassword(textToHash, 10, true);
        }

        public bool BcryptVerify(string textToHash, string hashedValue)
        {
            return BCrypt.Net.BCrypt.Verify(textToHash, hashedValue, true, BCrypt.Net.HashType.SHA256);
        }
    }
}
