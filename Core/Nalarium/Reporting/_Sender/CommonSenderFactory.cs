#region Copyright

//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010

#endregion

using System;
using System.Globalization;

namespace Nalarium.Reporting
{
    public class CommonSenderFactory : SenderFactory
    {
        //- @Create -//
        /// <summary>
        /// Creates a specified sender factory from the aliased name
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public override Sender Create(String name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                switch (name.ToLower(CultureInfo.CurrentCulture))
                {
                    case "email":
                        return new EmailSender();
                    case "eventlog":
                        return new EventLogSender();
                    case "debug":
                        return new DebugOutputSender();
                    case "trace":
                        return new TraceOutputSender();
                }
            }
            //+
            return null;
        }
    }
}