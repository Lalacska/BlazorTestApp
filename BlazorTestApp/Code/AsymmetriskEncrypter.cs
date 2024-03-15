using System.Security.Cryptography;
using System.Text;

namespace BlazorTestApp.Code
{
    public class AsymmetriskEncrypter
    {
        public static string Encrypt(string textToEncrypt, string publicKey) 
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider()) 
            {
                rsa.FromXmlString(publicKey);
                byte[] byteArrayTextToEncrypt = Encoding.UTF8.GetBytes(textToEncrypt);
                byte[] byteArrayEncryptedValue = rsa.Encrypt(byteArrayTextToEncrypt, true);
                var encryptedDataAsString = Convert.ToBase64String(byteArrayEncryptedValue);
                return encryptedDataAsString;

            }

        }
    }
}
