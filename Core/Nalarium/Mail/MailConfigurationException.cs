#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
using System.Configuration;
using System.Runtime.Serialization;
//+
namespace Nalarium.Mail
{
    [Serializable]
    public class MailConfigurationException : ConfigurationErrorsException
    {
        //- @Ctor -//
        public MailConfigurationException() { }
        public MailConfigurationException(String message) : base(message) { }
        public MailConfigurationException(String message, Exception inner) : base(message, inner) { }

        //- #Ctor -//
        protected MailConfigurationException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}