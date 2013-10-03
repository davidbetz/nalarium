#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using System.IO;
using System.Security.Cryptography;
using Nalarium.Configuration;
using Nalarium.IO;

namespace Nalarium.Cryptography
{
    /// <summary>
    /// Used to work with Rijndael cryptography.
    /// </summary>
    public static class Rijndael
    {
        public static String Encrypt(String text)
        {
            Byte[] iv = Convert.FromBase64String(ConfigAccessor.ApplicationSettings("RijndaelIV"));
            Byte[] key = Convert.FromBase64String(ConfigAccessor.ApplicationSettings("RijndaelKey"));
            //+
            return Encrypt(text, iv, key);
        }

        public static String Encrypt(String text, Byte[] iv, Byte[] key)
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
            ICryptoTransform transform = symm.CreateEncryptor();
            using (var cstream = new CryptoStream(output, transform, CryptoStreamMode.Write))
            {
                var br = new BinaryReader(memoryStream);
                cstream.Write(br.ReadBytes((int)memoryStream.Length), 0, (int)memoryStream.Length);
                cstream.FlushFinalBlock();
                //+
                return Convert.ToBase64String(output.ToArray());
            }
        }

        public static String Decrypt(String text)
        {
            Byte[] iv = Convert.FromBase64String(ConfigAccessor.ApplicationSettings("RijndaelIV"));
            Byte[] key = Convert.FromBase64String(ConfigAccessor.ApplicationSettings("RijndaelKey"));
            //+
            return Decrypt(text, iv, key);
        }

        public static String Decrypt(String text, Byte[] iv, Byte[] key)
        {
            var memoryStream = new MemoryStream(Convert.FromBase64String(text));
            //+
            var symm = new RijndaelManaged();
            symm.BlockSize = 128;
            symm.KeySize = 256;
            symm.IV = iv;
            symm.Key = key;
            ICryptoTransform transform = symm.CreateDecryptor();
            using (var cstream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read))
            {
                String output = new StreamReader(cstream).ReadToEnd();
                return output.Substring(1, output.Length - 1);
            }
        }
    }
}