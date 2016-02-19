#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System;

namespace Nalarium
{
    public static class BitOperation
    {
        public static string Execute(Func<byte[], byte[]> runner, string text)
        {
            return BitConverter.ToString(runner(System.Text.Encoding.UTF8.GetBytes(text)));
        }
    }
}