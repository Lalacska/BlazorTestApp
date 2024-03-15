using System.Security.Cryptography;
using System.Text;

namespace BlazorTestApp.Code
{
    public class AsymmetriskKrypteringHandler
    {
        private string _privateKey;
        private string _publicKey;
        public AsymmetriskKrypteringHandler()
        {

            string dataFolderPath = Path.Combine("Data", "Key"); 

            // Check if the directory exists, create it if it doesn't
            if (!Directory.Exists(dataFolderPath))
            {
                Directory.CreateDirectory(dataFolderPath);
            }

            string privateKeyFilePath = Path.Combine(dataFolderPath, "privateKey.xml");
            string publicKeyFilePath = Path.Combine(dataFolderPath, "publicKey.xml");


            // Check if the files exist
            if (!File.Exists(privateKeyFilePath) || !File.Exists(publicKeyFilePath))
            {
                using (RSA rsa = RSA.Create())
                {
                    // private key
                    RSAParameters privareKeyParams = rsa.ExportParameters(true);
                    _privateKey = rsa.ToXmlString(true);

                    // public key
                    RSAParameters publicKeyParams = rsa.ExportParameters(false);
                    _publicKey = rsa.ToXmlString(false);

                    // Write private key to file if it doesn't exist
                    if (!File.Exists(privateKeyFilePath))
                    {
                        File.WriteAllText(privateKeyFilePath, _privateKey);
                    }

                    // Write public key to file if it doesn't exist
                    if (!File.Exists(publicKeyFilePath))
                    {
                        File.WriteAllText(publicKeyFilePath, _publicKey);
                    }
                }
            }else
            {
                // Read keys from files
                _privateKey = File.ReadAllText(privateKeyFilePath);
                _publicKey = File.ReadAllText(publicKeyFilePath);
            }
        }

        public string Encrypt(string textToEncrypt)
        {
            string encryptedValue = AsymmetriskEncrypter.Encrypt(textToEncrypt, _publicKey);
            return encryptedValue;
        }

        public string Decrypt(string textToDecrypt)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(_privateKey);

                byte[] byteArrayTextToDecrypt = Convert.FromBase64String(textToDecrypt);
                byte[] byteArrayDecryptedValue = rsa.Decrypt(byteArrayTextToDecrypt, true);
                var decryptedDataAsString = Encoding.UTF8.GetString(byteArrayDecryptedValue);
                return decryptedDataAsString;
            }

        }
    }
}
