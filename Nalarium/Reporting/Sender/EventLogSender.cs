#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System.Diagnostics;

namespace Nalarium.Reporting.Sender
{
    public class EventLogSender : Sender
    {
        //- ~Setting -//

        //+
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
                if (data.Length > 32766)
                {
                    data = data.Substring(0, 32766);
                }
                if (!EventLog.SourceExists(Setting.Source))
                {
                    EventLog.CreateEventSource(Setting.Source, Setting.Source);
                }
                var log = new EventLog();
                log.Source = Setting.Source;
                if (isException)
                {
                    log.WriteEntry(data, EventLogEntryType.Error);
                }
                else
                {
                    log.WriteEntry(data, EventLogEntryType.Information);
                }
            }
        }

        #region Nested type: Setting

        internal class Setting
        {
            public const string Source = "David Betz 2007-2015";
        }

        #endregion
    }
}