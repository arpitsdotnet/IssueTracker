using System;
using System.IO;
using System.Security.Cryptography;

namespace IssueTracker.BusinessLayer.Services.Encryption
{
    public static class CryptographyUtility
    {
        public static string Encrypt(this string strText, string strEncrKey)
        {
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

            byte[] bykey = System.Text.Encoding.UTF8.GetBytes(strEncrKey.Substring(0, 8));
            byte[] InputByteArray = System.Text.Encoding.UTF8.GetBytes(strText);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(bykey, IV), CryptoStreamMode.Write);
            cs.Write(InputByteArray, 0, InputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());

        }
    }
}
