#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Nalarium.Cryptography
{
    /// <summary>
    /// Used to create quick MD5 hashes.
    /// </summary>
    public static class QuickHash
    {
        public static string Hash(string text)
        {
            using (var md5 = MD5.Create())
            {
                return BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(text))).Replace("-", "");
            }
        }

        public static string HashFile(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "");
                }
            }
        }

        public static string Hash(byte[] buffer)
        {
            using (var md5 = MD5.Create())
            {
                return BitConverter.ToString(md5.ComputeHash(buffer)).Replace("-", "");
            }
        }
    }
}