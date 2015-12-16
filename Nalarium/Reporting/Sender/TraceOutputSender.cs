#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System.Diagnostics;

namespace Nalarium.Reporting.Sender
{
    public class TraceOutputSender : Sender
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
                Trace.WriteLine(data);
                if (!string.IsNullOrEmpty(data))
                {
                    Trace.WriteLine(extra);
                }
            }
        }
    }
}