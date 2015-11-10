#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using Nalarium.Configuration.AppConfig;
using Nalarium.Mail;

//+

namespace Nalarium.Reporting.Sender
{
    public class EmailSender : Sender
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
                String to;
                String from;
                String subject = extra;
                Boolean givePrefix;
                if (isException)
                {
                    to = MailConfiguration.ExceptionToEmailAddress;
                    from = MailConfiguration.ExceptionFromEmailAddress;
                    if (String.IsNullOrEmpty(subject))
                    {
                        subject = MailConfiguration.ExceptionSubject;
                    }
                    givePrefix = MailConfiguration.ExceptionPrefixWithSiteName;
                }
                else
                {
                    to = MailConfiguration.GeneralToEmailAddress;
                    from = MailConfiguration.GeneralFromEmailAddress;
                    if (String.IsNullOrEmpty(subject))
                    {
                        subject = MailConfiguration.GeneralSubject;
                    }
                    givePrefix = MailConfiguration.GeneralPrefixWithSiteName;
                }
                if (givePrefix)
                {
                    SystemSection section = SystemSection.GetConfigSection();
                    if (section != null && section.AppInfo != null)
                    {
                        String name = section.AppInfo.Name;
                        if (!String.IsNullOrEmpty(name))
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