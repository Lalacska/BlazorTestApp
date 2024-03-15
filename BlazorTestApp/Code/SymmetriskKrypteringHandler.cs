using Microsoft.AspNetCore.DataProtection;

namespace BlazorTestApp.Code
{
    public class SymmetriskKrypteringHandler
    {
        private readonly IDataProtector _protector;
        public SymmetriskKrypteringHandler(IDataProtectionProvider protector)
        {
            _protector = protector.CreateProtector("SomethingForKeyOrIDK");
        }

        public string EncryptSymmetric(string textToEncrypt) => 
            _protector.Protect(textToEncrypt);

        public string DecryptSymmetric(string textToDecrypt) =>
            _protector.Unprotect(textToDecrypt);
    }
}
