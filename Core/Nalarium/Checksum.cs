using System;

namespace Nalarium
{
    public static class Checksum
    {
        public static Byte[] GetCrc(Byte[] array)
        {
            Int64 sum = 0;
            for (Int32 i = 0; i < (array.Length); i += 2)
            {
                var word16 = (UInt16)(((array[i] << 8) & 0xFF00) + (array[i + 1] & 0xFF));
                sum += word16;
            }

            while ((sum >> 16) != 0)
            {
                sum = (sum & 0xFFFF) + (sum >> 16);
            }

            sum = ~sum;

            return BitConverter.GetBytes((UInt16)sum);
        }
    }
}