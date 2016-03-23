#region Copyright

//+ Copyright © David Betz 2007-2016

#endregion

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;

namespace Nalarium.Cryptography
{
    public static class QuickHash
    {
        public static string Hash(string text, HashMethod method = HashMethod.MD5)
        {
            byte[] hash;
            switch (method)
            {
                case HashMethod.MD5:
                    using (var md5 = MD5.Create())
                        hash = md5.ComputeHash(Encoding.UTF8.GetBytes(text));
                    break;
                case HashMethod.SHA1:
                    using (var sha = new SHA1Managed())
                        hash = sha.ComputeHash(Encoding.UTF8.GetBytes(text));
                    break;
                case HashMethod.SHA256:
                    using (var sha = new SHA256Managed())
                        hash = sha.ComputeHash(Encoding.UTF8.GetBytes(text));
                    break;
                case HashMethod.SHA512:
                    using (var sha = new SHA512Managed())
                        hash = sha.ComputeHash(Encoding.UTF8.GetBytes(text));
                    break;
                case HashMethod.DoubleSHA256:
                    using (var sha = new SHA256Managed())
                        hash = sha.ComputeHash(sha.ComputeHash(Encoding.UTF8.GetBytes(text)));
                    break;
                default:
                    return string.Empty;
            }
            return BitConverter.ToString(hash).Replace("-", "");
        }

        public static string HashFile(string filename, HashMethod method = HashMethod.MD5)
        {
            byte[] hash;
            switch (method)
            {
                case HashMethod.MD5:
                    using (var md5 = MD5.Create())
                    using (var stream = File.OpenRead(filename))
                        hash = md5.ComputeHash(stream);
                    break;
                case HashMethod.SHA1:
                    using (var sha = new SHA1Managed())
                    using (var stream = File.OpenRead(filename))
                        hash = sha.ComputeHash(stream);
                    break;
                case HashMethod.SHA256:
                    using (var sha = new SHA256Managed())
                    using (var stream = File.OpenRead(filename))
                        hash = sha.ComputeHash(stream);
                    break;
                case HashMethod.SHA512:
                    using (var sha = new SHA512Managed())
                    using (var stream = File.OpenRead(filename))
                        hash = sha.ComputeHash(stream);
                    break;
                case HashMethod.DoubleSHA256:
                    using (var sha = new SHA256Managed())
                    using (var stream = File.OpenRead(filename))
                        hash = sha.ComputeHash(sha.ComputeHash(stream));
                    break;
                default:
                    return string.Empty;
            }
            return BitConverter.ToString(hash).Replace("-", "");
        }

        public static string Hash(object obj, HashMethod method = HashMethod.MD5)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);
                return Hash(stream.ToArray(), method);
            }
        }

        public static string Hash(byte[] buffer, HashMethod method = HashMethod.MD5)
        {
            byte[] hash;
            switch (method)
            {
                case HashMethod.MD5:
                    using (var md5 = MD5.Create())
                        hash = md5.ComputeHash(buffer);
                    break;
                case HashMethod.SHA1:
                    using (var sha = new SHA1Managed())
                        hash = sha.ComputeHash(buffer);
                    break;
                case HashMethod.SHA256:
                    using (var sha = new SHA256Managed())
                        hash = sha.ComputeHash(buffer);
                    break;
                case HashMethod.SHA512:
                    using (var sha = new SHA512Managed())
                        hash = sha.ComputeHash(buffer);
                    break;
                case HashMethod.DoubleSHA256:
                    using (var sha = new SHA256Managed())
                        hash = sha.ComputeHash(sha.ComputeHash(buffer));
                    break;
                default:
                    return string.Empty;
            }
            return BitConverter.ToString(hash).Replace("-", "");
        }
    }
}