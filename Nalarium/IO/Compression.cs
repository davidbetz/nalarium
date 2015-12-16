#region Copyright

//+ Copyright © David Betz 2008-2015

#endregion

using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;

namespace Nalarium.IO
{
    /// <summary>
    ///     Compresses and decompresses.
    /// </summary>
    public static class Compression
    {
        public static byte[] Compress(string input)
        {
            return Compress(Encoding.UTF8.GetBytes(input));
        }

        public static byte[] Compress(byte[] buffer)
        {
            using (var output = new MemoryStream())
            {
                using (var gzipStream = new GZipStream(output, CompressionMode.Compress))
                using (var input = new MemoryStream(buffer))
                {
                    input.CopyTo(gzipStream);
                }
                return output.ToArray();
            }
        }

        public static async Task<byte[]> CompressAsyc(byte[] buffer)
        {
            using (var output = new MemoryStream())
            {
                using (var gzipStream = new GZipStream(output, CompressionMode.Compress))
                using (var input = new MemoryStream(buffer))
                {
                    await input.CopyToAsync(gzipStream);
                }
                return output.ToArray();
            }
        }

        public static byte[] DecompressUsingSegments(byte[] buffer)
        {
            using (var input = new MemoryStream(buffer))
            using (var memory = new MemoryStream())
            using (var stream = new GZipStream(input, CompressionMode.Decompress))
            {
                const int size = 4096;
                var buffer2 = new byte[size];
                int count;
                do
                {
                    count = stream.Read(buffer2, 0, size);
                    if (count > 0)
                    {
                        memory.Write(buffer2, 0, count);
                    }
                } while (count > 0);
                return memory.ToArray();
            }
        }

        public static byte[] Decompress(byte[] buffer)
        {
            using (var input = new MemoryStream(buffer))
            using (var gzipStream = new GZipStream(input, CompressionMode.Decompress))
            using (var output = new MemoryStream())
            {
                gzipStream.CopyTo(output);
                return output.ToArray();
            }
        }

        public static async Task<byte[]> DecompressAsync(byte[] buffer)
        {
            using (var input = new MemoryStream(buffer))
            using (var gzipStream = new GZipStream(input, CompressionMode.Decompress))
            using (var output = new MemoryStream())
            {
                await gzipStream.CopyToAsync(output);
                return output.ToArray();
            }
        }

        public static string DecompressToString(byte[] input)
        {
            return Encoding.UTF8.GetString(Decompress(input));
        }
    }
}