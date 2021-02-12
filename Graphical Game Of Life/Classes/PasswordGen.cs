using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hashing
{
    static class PasswordGen
    {
        // Static Attributes
        static Random random = new Random();
        public static (byte[] hash, byte[] salt) NewSaltedHash(string password, byte[] salt = null)
        {
            SHA256 alg = SHA256.Create();
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            if (salt == null || salt.Length != 32)
            {
                salt = new byte[32];
                random.NextBytes(salt);
            }
            byte[] hash = alg.ComputeHash(ConcatenateByteArrays(passwordBytes, salt));
            return (hash, salt);
        }
        public static byte[] GenerateHash(string password, byte[] salt)
        {
            SHA256 alg = SHA256.Create();
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = alg.ComputeHash(ConcatenateByteArrays(passwordBytes, salt));
            return hash;
        }
        private static byte[] ConcatenateByteArrays(byte[] arr1, byte[] arr2)
        {
            byte[] combined = new byte[arr1.Length + arr2.Length];
            for (int i = 0; i < arr1.Length; i++)
            {
                combined[i] = arr1[i];
            }
            for (int i = 0; i < arr2.Length; i++)
            {
                combined[i + arr1.Length] = arr2[i];
            }
            return combined;
        }
    }
}
