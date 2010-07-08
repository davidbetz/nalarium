#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
using System.Security.Cryptography;
using System.IO;
//+
namespace Nalarium.Cryptography
{
    /// <summary>
    /// Used to work with Rijndael cryptography.
    /// </summary>
    public static class Rijndael
    {
        public static String Encrypt(String text)
        {
            var rijndael = System.Security.Cryptography.Rijndael.Create();
            MemoryStream memoryStream = Nalarium.IO.StreamConverter.CreateStream<MemoryStream>(text);
            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndael.CreateEncryptor(rijndael.Key, rijndael.IV), CryptoStreamMode.Write))
            {
                String data = String.Empty;
                new StreamWriter(cryptoStream).Write(data);
                return data;
            }
        }

        public static String Decrypt(String text)
        {
            var rijndael = System.Security.Cryptography.Rijndael.Create();
            MemoryStream memoryStream = Nalarium.IO.StreamConverter.CreateStream<MemoryStream>(text);
            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndael.CreateDecryptor(rijndael.Key, rijndael.IV), CryptoStreamMode.Write))
            {
                return new StreamReader(cryptoStream).ReadToEnd();
            }
        }
    }
}