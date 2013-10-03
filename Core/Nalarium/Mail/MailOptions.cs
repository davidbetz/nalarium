#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;

namespace Nalarium.Mail
{
    /// <summary>
    /// Represents the various mail sending options.
    /// </summary>
    [Flags]
    public enum MailOptions
    {
        IsHtml = 0x01,
        UseSecureGmail = 0x02,
        UseGmailConversationBreaker = 0x04
    }
}