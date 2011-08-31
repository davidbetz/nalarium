#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Net;
using System.Text;

namespace Nalarium.Web.AccessRule
{
    public class HostConditionExecutor : ConditionExecutor
    {
        private readonly Object _lock = new Object();
        private readonly Map<String, String> addressMap = new Map<String, String>();

        //+
        //- @Process -//
        public override Boolean Process()
        {
            if (String.IsNullOrEmpty(Usage) || Usage.Equals("from", StringComparison.CurrentCultureIgnoreCase))
            {
                return Value == Http.IPAddress;
            }
            else if (Usage.Equals("to", StringComparison.CurrentCultureIgnoreCase))
            {
                lock (_lock)
                {
                    String address;
                    if (addressMap.ContainsKey(Http.Domain))
                    {
                        address = addressMap[Http.Domain];
                    }
                    else
                    {
                        IPHostEntry host = Dns.GetHostEntry(Http.Domain);
                        if (host == null || Collection.IsNullOrEmpty(host.AddressList))
                        {
                            return false;
                        }
                        //+
                        address = Encoding.UTF8.GetString(host.AddressList[0].GetAddressBytes());
                        addressMap[Http.Domain] = address;
                    }
                    //+
                    return address == Value;
                }
            }
            //+
            return false;
        }
    }
}