#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System.Globalization;

namespace Nalarium.Reporting.Sender
{
    public class CommonSenderFactory : SenderFactory
    {
        //- @Create -//
        /// <summary>
        ///     Creates a specified sender factory from the aliased name
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public override Sender Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
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