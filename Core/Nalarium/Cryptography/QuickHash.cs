#region Copyright

//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010

#endregion

using System;
using System.Security.Cryptography;
using System.Text;

namespace Nalarium.Cryptography
{
    /// <summary>
    /// Used to create quick MD5 hashes.
    /// </summary>
    public static class QuickHash
    {
        public static String Hash(String text)
        {
            return Convert.ToBase64String(new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(text)));
        }
    }
}