#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using Nalarium.Configuration.AppConfig;
using Nalarium.Mail;

//+

namespace Nalarium.Reporting.Sender
{
    public class EmailSender : Sender
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
                string to;
                string from;
                var subject = extra;
                bool givePrefix;
                if (isException)
                {
                    to = MailConfiguration.ExceptionToEmailAddress;
                    from = MailConfiguration.ExceptionFromEmailAddress;
                    if (string.IsNullOrEmpty(subject))
                    {
                        subject = MailConfiguration.ExceptionSubject;
                    }
                    givePrefix = MailConfiguration.ExceptionPrefixWithSiteName;
                }
                else
                {
                    to = MailConfiguration.GeneralToEmailAddress;
                    from = MailConfiguration.GeneralFromEmailAddress;
                    if (string.IsNullOrEmpty(subject))
                    {
                        subject = MailConfiguration.GeneralSubject;
                    }
                    givePrefix = MailConfiguration.GeneralPrefixWithSiteName;
                }
                if (givePrefix)
                {
                    var section = SystemSection.GetConfigSection();
                    if (section != null && section.AppInfo != null)
                    {
                        var name = section.AppInfo.Name;
                        if (!string.IsNullOrEmpty(name))
                        {
                            subject = name + " - " + subject;
                        }
                    }
                }
                //+
                Emailer.Send(from, to, subject, data, MailOptionsCreator.Create(ContentType == "text/html", MailConfiguration.UseSecureGmailByDefault, isException && MailConfiguration.UseGmailConverationBreakerForExceptionReport));
            }
        }
    }
}