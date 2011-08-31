#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Net;

namespace Nalarium.Web.AccessRule
{
    public class RangeConditionExecutor : ConditionExecutor
    {
        private readonly Object _lock = new Object();
        private readonly Map<String, UInt32> valueMap = new Map<String, UInt32>();

        //+
        //- @Process -//
        public override Boolean Process()
        {
            //++ example: {Range 67.99.12.100-67.99.12.200}
            //+
            if (!Value.Contains("-"))
            {
                return false;
            }
            String[] partArray = Value.Split('-');
            String current = Http.IPAddress;
            String first = partArray[0].Trim();
            String second = partArray[1].Trim();
            UInt32 currentValue = GetIPAddressValue(current);
            UInt32 firstValue = GetIPAddressValue(first);
            UInt32 secondValue = GetIPAddressValue(second);
            //+
            if (currentValue == 0 || firstValue == 0 || secondValue == 0)
            {
                return false;
            }
            if (currentValue >= firstValue && currentValue <= secondValue)
            {
                return true;
            }
            //+
            return false;
        }

        //- $GetIPAddressValue -//
        private UInt32 GetIPAddressValue(string address)
        {
            lock (_lock)
            {
                UInt32 value;
                if (valueMap.ContainsKey(address))
                {
                    return valueMap[address];
                }
                //+
                IPAddress currentIPAddress;
                if (!IPAddress.TryParse(address, out currentIPAddress))
                {
                    return 0;
                }
                //+
                value = 0;
                Byte[] currentIPAddressByteArray = currentIPAddress.GetAddressBytes();
                value += (UInt32)currentIPAddressByteArray[0] << 24;
                value += (UInt32)currentIPAddressByteArray[1] << 16;
                value += (UInt32)currentIPAddressByteArray[2] << 8;
                value += currentIPAddressByteArray[3];
                //+
                valueMap[address] = value;
                //+
                return value;
            }
        }
    }
}