#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

namespace Nalarium.Mail
{
    /// <summary>
    ///     Creates mail options for use with mail operations.
    /// </summary>
    public static class MailOptionsCreator
    {
        //- @Create -//
        /// <summary>
        ///     Creates a MailOptions flags object to combine multiple booleans.
        /// </summary>
        /// <param name="isHtml">True if e-mail is to be sent as HTML.</param>
        /// <param name="useSecureGmail">True if Gmail's secure server should be used.</param>
        /// <param name="useGmailConversationBreaker">True if Gmail conversation breaker should be used.</param>
        /// <returns>MailOptions flags object with combines values.</returns>
        public static MailOptions Create(bool isHtml, bool useSecureGmail, bool useGmailConversationBreaker)
        {
            var option = new MailOptions();
            if (isHtml)
            {
                option = option | MailOptions.IsHtml;
            }
            if (useSecureGmail)
            {
                option = option | MailOptions.UseSecureGmail;
            }
            if (useGmailConversationBreaker)
            {
                option = option | MailOptions.UseGmailConversationBreaker;
            }
            //+
            return option;
        }
    }
}