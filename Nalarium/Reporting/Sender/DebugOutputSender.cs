﻿#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System.Diagnostics;

namespace Nalarium.Reporting.Sender
{
    public class DebugOutputSender : Sender
    {
        //- @SendCore -//
        /// <summary>
        ///     Sends the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="extra">The extra.</param>
        /// <param name="isException">if set to <c>true</c> [is exception].</param>
        protected override void SendCore(string data, string extra, bool isException)
        {
            if (!string.IsNullOrEmpty(data))
            {
                Debug.WriteLine(data);
                if (!string.IsNullOrEmpty(data))
                {
                    Debug.WriteLine(extra);
                }
            }
        }
    }
}