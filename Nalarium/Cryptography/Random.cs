#region Copyright

//+ Copyright © David Betz 2007-2016

#endregion

using System.Security.Cryptography;

namespace Nalarium.Cryptography
{
    public static class Random
    {
        public static long Create(int size)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var rn = new byte[size];
                rng.GetBytes(rn);
                if(size < 8)
                {
                    var temp = new byte[8];
                    rn.CopyTo(temp, 0);
                    rn = temp;
                }
                return System.BitConverter.ToInt64(rn, 0);
            }
        }
    }
}