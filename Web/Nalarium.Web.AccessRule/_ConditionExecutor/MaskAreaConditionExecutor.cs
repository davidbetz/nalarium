#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
namespace Nalarium.Web.AccessRule
{
    public class MaskAreaConditionExecutor : ConditionExecutor
    {

        //- @Process -//
        public override Boolean Process()
        {
            //++ example: {MaskArea 10.1.0.0 255.255.0.0}
            if (String.IsNullOrEmpty(Value))
            {
                return false;
            }
            String text = Value.Trim();
            if (String.IsNullOrEmpty(text))
            {
                return false;
            }
            if (!text.Contains(" "))
            {
                return false;
            }
            String[] partArray = text.Split(' ');
            if (partArray.Length != 2)
            {
                return false;
            }
            String network = partArray[0];
            String mask = partArray[1];
            //+ 72
            //+ 0100 1000
            Byte[] networkBinary = GetBinary(network);
            Byte[] maskBinary = GetBinary(mask);
            Byte[] currentBinary = GetBinary(Http.IPAddress);
            //+
            Boolean execute = false;
            for (Int32 i = 0; i < 32; i++)
            {
                if (maskBinary[i] == 1 && (networkBinary[i] != currentBinary[i]))
                {
                    execute = true;
                    break;
                }
            }
            //+
            return execute;
        }

        //- $GetBinary -//
        private Byte[] GetBinary(String text)
        {
            Byte[] result = new Byte[32];
            System.Net.IPAddress ipAddress;
            if (!System.Net.IPAddress.TryParse(text, out ipAddress))
            {
                return null;
            }
            Byte[] ipAddressByteArray = ipAddress.GetAddressBytes();
            UInt32 value = 0;
            value += (UInt32)ipAddressByteArray[0] << 24;
            value += (UInt32)ipAddressByteArray[1] << 16;
            value += (UInt32)ipAddressByteArray[2] << 8;
            value += (UInt32)ipAddressByteArray[3];
            for (Int32 i = 0; i < 32; i++)
            {
                UInt32 position = (UInt32)(1 << i);
                result[i] = (Byte)((value & position) == position ? 1 : 0);
            }
            //+
            return result;
        }
    }
}