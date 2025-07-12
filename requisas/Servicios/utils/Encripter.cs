using Microsoft.AspNetCore.DataProtection;
using System.Security.Cryptography;

namespace Servicios.utils
{
    public static class Encripter
    {
        private static readonly IDataProtector _protector;

        static Encripter()
        {
            // Ruta para persistir las claves (puedes cambiarla)
            string rutaProteccion = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProteccionClaves");

            var provider = DataProtectionProvider.Create(new DirectoryInfo(rutaProteccion));
            _protector = provider.CreateProtector("Nimac.Protector");
        }

        public static string Encrypt(string data)
        {
            return _protector.Protect(data);
        }

        public static string? Decrypt(string data)
        {
            try
            {
                return _protector.Unprotect(data);
            }
            catch (CryptographicException)
            {
                return null;
            }
        }
    }
}
