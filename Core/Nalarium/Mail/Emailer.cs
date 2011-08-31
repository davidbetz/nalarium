#region Copyright

//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010

#endregion

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace Nalarium.Mail
{
    /// <summary>
    /// Used to send e-mail.
    /// </summary>
    public static class Emailer
    {
        //- @Send -//
        /// <summary>
        /// Sends an e-mail using current date and time.
        /// </summary>
        /// <param name="from">From name and address</param>
        /// <param name="to">To name and address</param>
        /// <param name="subject">E-mail subject</param>
        /// <param name="body">E-Mail body text</param>
        public static void Send(String from, String to, String subject, String body)
        {
            Send(from, to, subject, body, new MailOptions());
        }

        /// <summary>
        /// Sends an e-mail using current date and time.
        /// </summary>
        /// <param name="from">From name and address</param>
        /// <param name="to">To name and address</param>
        /// <param name="subject">E-mail subject</param>
        /// <param name="body">E-Mail body text</param>
        /// <param name="options">Mail options to tell the system how the e-mail is to be sent</param>
        public static void Send(String from, String to, String subject, String body, MailOptions options)
        {
            Send(from, to, subject, body, DateTime.Now, options);
        }

        /// <summary>
        /// Sends an e-mail using a specific date and time.
        /// </summary>
        /// <param name="from">From name and address</param>
        /// <param name="to">To name and address</param>
        /// <param name="subject">E-mail subject</param>
        /// <param name="body">E-Mail body text</param>
        /// <param name="datetime">Date and time to mark on the e-mail</param>
        /// <param name="options">Mail options to tell the system how the e-mail is to be sent</param>
        public static void Send(String from, String to, String subject, String body, DateTime datetime, MailOptions options)
        {
            Send(from, to, subject, body, datetime, null, null, null, options);
        }

        /// <summary>
        /// Sends an e-mail using a specific date and time.
        /// </summary>
        /// <param name="from">From name and address</param>
        /// <param name="to">To name and address</param>
        /// <param name="subject">E-mail subject</param>
        /// <param name="body">E-Mail body text</param>
        /// <param name="datetime">Date and time to mark on the e-mail</param>
        /// <param name="cc">Comma separated CC list</param>
        /// <param name="bcc">Comma separated BCC list</param>
        /// <param name="attachmentPaths">Attachment paths</param>
        /// <param name="options">Mail options to tell the system how the e-mail is to be sent</param>
        public static void Send(String from, String to, String subject, String body, DateTime datetime, String cc, String bcc, List<String> attachmentPaths, MailOptions options)
        {
            InternalSend(from, to, subject, body, datetime, cc, bcc, attachmentPaths, options);
        }

        //- $InternalSend -//
        private static void InternalSend(String from, String to, String subject, String body, DateTime datetime, String cc, String bcc, List<String> attachmentPaths, MailOptions mailOptions)
        {
            if ((mailOptions & MailOptions.UseGmailConversationBreaker) == MailOptions.UseGmailConversationBreaker)
            {
                subject += " " + GuidCreator.GetNewGuid();
            }
            using (var email = new MailMessage(from, to))
            {
                email.Subject = subject;
                email.Body = body;
                email.IsBodyHtml = (mailOptions & MailOptions.IsHtml) == MailOptions.IsHtml;
                //+
                AssignCc(email, cc);
                AssignBcc(email, bcc);
                AssignAttachments(email, attachmentPaths);
                //+
                var mailClient = new SmtpClient();
                String userName = "agapeton";
                String password = "mscw0000";
                var basicAuthenticationInfo = new NetworkCredential(userName, password);
                if ((mailOptions & MailOptions.UseSecureGmail) == MailOptions.UseSecureGmail)
                {
                    mailClient.Host = "smtp.gmail.com";
                    mailClient.Port = 587;
                    mailClient.Credentials = basicAuthenticationInfo;
                    mailClient.EnableSsl = true;
                }
                else
                {
                    String server = MailConfiguration.Server;
                    mailClient.Host = server;
                    mailClient.UseDefaultCredentials = false;
                    mailClient.Credentials = basicAuthenticationInfo;
                }
                mailClient.Send(email);
            }
        }

        //- $AssignBcc -//
        private static void AssignBcc(MailMessage email, String bcc)
        {
            if (!String.IsNullOrEmpty(bcc))
            {
                foreach (String address in bcc.Split(",".ToCharArray()))
                {
                    email.Bcc.Add(address);
                }
            }
        }

        //- $AssignCc -//
        private static void AssignCc(MailMessage email, String cc)
        {
            if (!String.IsNullOrEmpty(cc))
            {
                foreach (String address in cc.Split(",".ToCharArray()))
                {
                    email.CC.Add(address);
                }
            }
        }

        //- $AssignAttachments -//
        private static void AssignAttachments(MailMessage email, List<String> attachmentPaths)
        {
            if (attachmentPaths != null)
            {
                foreach (String file in attachmentPaths)
                {
                    email.Attachments.Add(new Attachment(file));
                }
            }
        }
    }
}