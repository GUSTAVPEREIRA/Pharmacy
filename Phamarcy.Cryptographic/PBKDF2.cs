using System;
using System.Security.Cryptography;

namespace Pharmacy.Cryptographic
{
    public class PBKDF2 : BaseCryptographic
    {
        public override string Encrypt(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var result = CreateHash(password, salt, 100000);
            var hash = result.GetBytes(20);

            byte[] hashBytes = new byte[36];

            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }

        public override bool Verify(string password, string savedPassword)
        {
            string savedPasswordHash = savedPassword;
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            /* Compare the results */
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }
            }

            return true;
        }

        private Rfc2898DeriveBytes CreateHash(string password, byte[] salt, int number)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, number);
            return pbkdf2;
        }
    }
}