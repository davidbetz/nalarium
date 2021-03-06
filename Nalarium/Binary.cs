#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System.Collections.Generic;

namespace Nalarium
{
    public static class Binary
    {
        public static long[] Decompose(long value)
        {
            var list = new List<long>();
            long i = 1;
            while (i <= value)
            {
                if ((i & value) == i)
                {
                    list.Add(i);
                }
                i <<= 1;
            }
            return list.ToArray();
        }
    }
}