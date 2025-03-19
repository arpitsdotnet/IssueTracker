using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace IssueTracker.BusinessLayer.Services.Encryption
{
    public static class SsplSecurity
    {
        private static readonly byte[] initializationVector = new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

        public static string Encrypt(string text, string salt)
        {
            byte[] inputArray = Encoding.UTF8.GetBytes(text);
            byte[] saltedKey = Encoding.UTF8.GetBytes(salt.Substring(0, 8));

            var ms = new MemoryStream();
            using (var cs = new CryptoStream(ms,
                new DESCryptoServiceProvider().CreateEncryptor(saltedKey, initializationVector),
                CryptoStreamMode.Write))
            {
                cs.Write(inputArray, 0, inputArray.Length);
                cs.FlushFinalBlock();
            }

            return Convert.ToBase64String(ms.ToArray());
        }

        public static string Decrypt(string text, string salt)
        {
            byte[] inputArray = Convert.FromBase64String(text);
            byte[] saltedKey = Encoding.UTF8.GetBytes(salt.Substring(0, 8));

            var ms = new MemoryStream();
            using (var cs = new CryptoStream(ms,
                new DESCryptoServiceProvider().CreateDecryptor(saltedKey, initializationVector),
                CryptoStreamMode.Write))
            {
                cs.Write(inputArray, 0, inputArray.Length);
                cs.FlushFinalBlock();
            }

            Encoding encoding = Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }

        public static string CreateSimpleHash(string text, string salt)
        {
            byte[] inputArray = Encoding.UTF8.GetBytes(text);
            byte[] saltedKey = Encoding.UTF8.GetBytes(salt.Substring(0, 8));

            return string.Join(",", inputArray) + "." + string.Join(",", saltedKey);
        }
    }
}
