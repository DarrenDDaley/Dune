using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Dune
{
    public static class Hash
    {
        private static byte[] salt = new byte[128 / 8];

        public static string Password(string password)
        {
            using (var rng = RandomNumberGenerator.Create()) {
                rng.GetBytes(salt);
            }

            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password, 
                salt,
                KeyDerivationPrf.HMACSHA1, 
                10,
                256 / 8));
        }
    }
}
