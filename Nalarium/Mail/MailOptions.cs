#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System;

namespace Nalarium.Mail
{
    /// <summary>
    ///     Represents the various mail sending options.
    /// </summary>
    [Flags]
    public enum MailOptions
    {
        IsHtml = 0x01,
        UseSecureGmail = 0x02,
        UseGmailConversationBreaker = 0x04
    }
}