﻿#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using System.Diagnostics;

namespace Nalarium.Reporting.Sender
{
    public class TraceOutputSender : Sender
    {
        //- @SendCore -//
        /// <summary>
        /// Sends the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="extra">The extra.</param>
        /// <param name="isException">if set to <c>true</c> [is exception].</param>
        protected override void SendCore(String data, String extra, Boolean isException)
        {
            if (!String.IsNullOrEmpty(data))
            {
                Trace.WriteLine(data);
                if (!String.IsNullOrEmpty(data))
                {
                    Trace.WriteLine(extra);
                }
            }
        }
    }
}