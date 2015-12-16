#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System;
using System.Configuration;
using System.Runtime.Serialization;

namespace Nalarium.Mail
{
    [Serializable]
    public class MailConfigurationException : ConfigurationErrorsException
    {
        //- @Ctor -//
        public MailConfigurationException()
        {
        }

        public MailConfigurationException(string message)
            : base(message)
        {
        }

        public MailConfigurationException(string message, Exception inner)
            : base(message, inner)
        {
        }

        //- #Ctor -//
        protected MailConfigurationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}