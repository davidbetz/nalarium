#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
using System.Diagnostics;
//+
namespace Nalarium.Reporting
{
    public class DebugOutputSender : Sender
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
                System.Diagnostics.Debug.WriteLine(data);
                if (!String.IsNullOrEmpty(data))
                {
                    System.Diagnostics.Debug.WriteLine(extra);
                }
            }
        }
    }
}