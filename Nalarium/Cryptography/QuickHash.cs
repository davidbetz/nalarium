#region Copyright

//+ Copyright © David Betz 2007-2016

#endregion

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Nalarium.Cryptography
{
    public static class QuickHash
    {
        public static string Hash(string text, HashMethod method = HashMethod.MD5)
        {
            switch (method)
            {
                case HashMethod.MD5:
                    using (var md5 = MD5.Create())
                        return BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(text))).Replace("-", "");
                case HashMethod.SHA256:
                    using (var sha = new SHA256Managed())
                        return BitConverter.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(text))).Replace("-", "");
                default:
                    return string.Empty;
            }
        }

        public static string HashFile(string filename, HashMethod method = HashMethod.MD5)
        {
            switch (method)
            {
                case HashMethod.MD5:
                    using (var md5 = MD5.Create())
                    using (var stream = File.OpenRead(filename))
                        return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "");
                case HashMethod.SHA256:
                    using (var sha = new SHA256Managed())
                    using (var stream = File.OpenRead(filename))
                        return BitConverter.ToString(sha.ComputeHash(stream)).Replace("-", "");
                default:
                    return string.Empty;
            }
        }

        public static string Hash(byte[] buffer, HashMethod method = HashMethod.MD5)
        {
            switch (method)
            {
                case HashMethod.MD5:
                    using (var md5 = MD5.Create())
                        return BitConverter.ToString(md5.ComputeHash(buffer)).Replace("-", "");
                case HashMethod.SHA256:
                    using (var sha = new SHA256Managed())
                        return BitConverter.ToString(sha.ComputeHash(buffer)).Replace("-", "");
                default:
                    return string.Empty;
            }
        }
    }
}