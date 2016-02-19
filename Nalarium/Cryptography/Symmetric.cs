#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System;
using System.IO;
using System.Security.Cryptography;
using Nalarium.Configuration;
using Nalarium.IO;

namespace Nalarium.Cryptography
{
    /// <summary>
    ///     Used to work with Symmetric cryptography.
    /// </summary>
    public static class Symmetric
    {
        public static string Encrypt(string text, SymmetricMethod method = SymmetricMethod.Rijndael)
        {
            var iv = Convert.FromBase64String(ConfigAccessor.ApplicationSettings("RijndaelIV"));
            var key = Convert.FromBase64String(ConfigAccessor.ApplicationSettings("RijndaelKey"));
            //+
            return Encrypt(text, iv, key, method);
        }

        public static string Encrypt(string text, byte[] iv, byte[] key, SymmetricMethod method = SymmetricMethod.Rijndael)
        {
            var memoryStream = StreamConverter.CreateStream<MemoryStream>(text);
            memoryStream.Seek(0, SeekOrigin.Begin);
            //+
            var output = new MemoryStream();
            SymmetricAlgorithm symm = null;
            switch (method)
            {
                case SymmetricMethod.Rijndael:
                    symm = new RijndaelManaged();
                    break;
                case SymmetricMethod.Aes:
                    symm = new AesManaged();
                    break;
                default:
                    return string.Empty;
            }
            symm.BlockSize = 128;
            symm.KeySize = 256;
            symm.IV = iv;
            symm.Key = key;
            var transform = symm.CreateEncryptor();
            using (var cstream = new CryptoStream(output, transform, CryptoStreamMode.Write))
            {
                var br = new BinaryReader(memoryStream);
                cstream.Write(br.ReadBytes((int)memoryStream.Length), 0, (int)memoryStream.Length);
                cstream.FlushFinalBlock();
                //+
                return Convert.ToBase64String(output.ToArray());
            }
        }

        public static string Decrypt(string text, SymmetricMethod method = SymmetricMethod.Rijndael)
        {
            var iv = Convert.FromBase64String(ConfigAccessor.ApplicationSettings("RijndaelIV"));
            var key = Convert.FromBase64String(ConfigAccessor.ApplicationSettings("RijndaelKey"));
            //+
            return Decrypt(text, iv, key, method);
        }

        public static string Decrypt(string text, byte[] iv, byte[] key, SymmetricMethod method = SymmetricMethod.Rijndael)
        {
            var memoryStream = new MemoryStream(Convert.FromBase64String(text));
            //+
            SymmetricAlgorithm symm = null;
            switch (method)
            { 
                case SymmetricMethod.Rijndael:
                    symm = new RijndaelManaged();
                    break;
                case SymmetricMethod.Aes:
                    symm = new AesManaged();
                    break;
                default:
                    return string.Empty;
            }
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