#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System;
using System.IO;
using System.Security.Cryptography;
using Nalarium.Configuration;
using Nalarium.IO;

namespace Nalarium.Cryptography
{
    [Obsolete("Use Symmetric.")]
    public static class Rijndael
    {
        public static string Encrypt(string text)
        {
            var iv = Convert.FromBase64String(ConfigAccessor.ApplicationSettings("RijndaelIV"));
            var key = Convert.FromBase64String(ConfigAccessor.ApplicationSettings("RijndaelKey"));
            //+
            return Encrypt(text, iv, key);
        }

        public static string Encrypt(string text, byte[] iv, byte[] key)
        {
            var memoryStream = StreamConverter.CreateStream<MemoryStream>(text);
            memoryStream.Seek(0, SeekOrigin.Begin);
            //+
            var output = new MemoryStream();
            var symm = new RijndaelManaged();
            symm.BlockSize = 128;
            symm.KeySize = 256;
            symm.IV = iv;
            symm.Key = key;
            var transform = symm.CreateEncryptor();
            using (var cstream = new CryptoStream(output, transform, CryptoStreamMode.Write))
            {
                var br = new BinaryReader(memoryStream);
                cstream.Write(br.ReadBytes((int) memoryStream.Length), 0, (int) memoryStream.Length);
                cstream.FlushFinalBlock();
                //+
                return Convert.ToBase64String(output.ToArray());
            }
        }

        public static string Decrypt(string text)
        {
            var iv = Convert.FromBase64String(ConfigAccessor.ApplicationSettings("RijndaelIV"));
            var key = Convert.FromBase64String(ConfigAccessor.ApplicationSettings("RijndaelKey"));
            //+
            return Decrypt(text, iv, key);
        }

        public static string Decrypt(string text, byte[] iv, byte[] key)
        {
            var memoryStream = new MemoryStream(Convert.FromBase64String(text));
            //+
            var symm = new RijndaelManaged();
            symm.BlockSize = 128;
            symm.KeySize = 256;
            symm.IV = iv;
            symm.Key = key;
            var transform = symm.CreateDecryptor();
            using (var cstream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read))
            {
                var output = new StreamReader(cstream).ReadToEnd();
                return output.Substring(1, output.Length - 1);
            }
        }
    }
}