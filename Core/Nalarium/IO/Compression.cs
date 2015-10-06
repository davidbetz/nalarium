#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System.IO;
using System.IO.Compression;
using System.Text;

namespace Nalarium.IO
{
    /// <summary>
    /// Compresses and decompresses.
    /// </summary>
    public static class Compression
    {
        public static byte[] Compress(string input)
        {
            return Compress(Encoding.UTF8.GetBytes(input));
        }

        public static byte[] Compress(byte[] input)
        {
            using (var memoryStream = new MemoryStream())
            using (var gzipStream = new GZipStream(memoryStream, CompressionLevel.Optimal, true))
            {
                gzipStream.Write(input, 0, input.Length);
                return memoryStream.ToArray();
            }
        }

        public static byte[] Decompress(byte[] input)
        {
            using (var stream = new GZipStream(new MemoryStream(input), CompressionMode.Decompress))
            {
                const int size = 4096;
                byte[] buffer = new byte[size];
                using (MemoryStream memory = new MemoryStream())
                {
                    int count = 0;
                    do
                    {
                        count = stream.Read(buffer, 0, size);
                        if (count > 0)
                        {
                            memory.Write(buffer, 0, count);
                        }
                    } while (count > 0);
                    return memory.ToArray();
                }
            }
        }

        public static string DecompressToString(byte[] input)
        {
            return Encoding.UTF8.GetString(Decompress(input));
        }
    }
}