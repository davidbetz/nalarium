#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright � Jampad Technology, Inc. 2007-2010
#endregion
using System;
using Nalarium.Configuration;
//+
namespace Nalarium.Mail
{
    /// <summary>
    /// Provides quick access to mail configuration.
    /// </summary>
    public static class MailConfiguration
    {
        //- $Section -//
        private static SystemSection Section
        {
            get
            {
                return SystemSection.GetConfigSection();
            }
        }

        //++
        //- @Server -//
        /// <summary>
        /// Gets the server.
        /// </summary>
        /// <value>The server.</value>
        public static String Server
        {
            get { return Section.EmailSetup.Server; }
        }

        //- @UserName -//
        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public static String UserName
        {
            get { return Section.EmailSetup.UserName; }
        }

        //- @Password -//
        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <value>The password.</value>
        public static String Password
        {
            get
            {
                String password = Section.EmailSetup.Password;
                if (password.StartsWith("secure:"))
                {
                    password = Nalarium.Cryptography.Rijndael.Decrypt(password.Substring("secure:".Length, password.Length - "secure:".Length));
                }
                return password;
            }
        }

        //++ parameters
        //- @GeneralToEmailAddress -//
        /// <summary>
        /// Gets the general to email address.
        /// </summary>
        /// <value>The general to email address.</value>
        public static String GeneralToEmailAddress
        {
            get { return GetParameterOrDefault("GeneralTo", Section.EmailSetup.To); }
        }

        //- @GeneralFromEmailAddress -//
        /// <summary>
        /// Gets the general from email address.
        /// </summary>
        /// <value>The general from email address.</value>
        public static String GeneralFromEmailAddress
        {
            get { return GetParameterOrDefault("GeneralFrom", Section.EmailSetup.From); }
        }

        //- @GeneralSubject -//
        /// <summary>
        /// Gets the general subject.
        /// </summary>
        /// <value>The general subject.</value>
        public static String GeneralSubject
        {
            get { return GetParameter("GeneralSubject"); }
        }

        //- @GeneralPrefixWithSiteName -//
        /// <summary>
        /// Gets a value indicating whether [general prefix with site name].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [general prefix with site name]; otherwise, <c>false</c>.
        /// </value>
        public static Boolean GeneralPrefixWithSiteName
        {
            get
            {
                return Parser.ParseBoolean(GetParameter("GeneralPrefixWithSiteName"), false);
            }
        }

        //- @ExceptionToEmailAddress -//
        /// <summary>
        /// Gets the exception to email address.
        /// </summary>
        /// <value>The exception to email address.</value>
        public static String ExceptionToEmailAddress
        {
            get { return GetParameterOrDefault("ExceptionTo", Section.EmailSetup.To); }
        }

        //- @ExceptionFromEmailAddress -//
        /// <summary>
        /// Gets the exception from email address.
        /// </summary>
        /// <value>The exception from email address.</value>
        public static String ExceptionFromEmailAddress
        {
            get { return GetParameterOrDefault("ExceptionFrom", Section.EmailSetup.From); }
        }

        //- @ExceptionSubject -//
        /// <summary>
        /// Gets the exception subject.
        /// </summary>
        /// <value>The exception subject.</value>
        public static String ExceptionSubject
        {
            get { return GetParameter("ExceptionSubject"); }
        }

        //- @ExceptionPrefixWithSiteName -//
        /// <summary>
        /// Gets a value indicating whether [exception prefix with site name].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [exception prefix with site name]; otherwise, <c>false</c>.
        /// </value>
        public static Boolean ExceptionPrefixWithSiteName
        {
            get
            {
                return Parser.ParseBoolean(GetParameter("ExceptionPrefixWithSiteName"), false);
            }
        }

        //- @UseSecureGmailByDefault -//
        /// <summary>
        /// Gets a value indicating whether [always use secure gmail].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [always use secure gmail]; otherwise, <c>false</c>.
        /// </value>
        public static Boolean UseSecureGmailByDefault
        {
            get
            {
                return Parser.ParseBoolean(GetParameter("UseSecureGmailByDefault"), false);
            }
        }

        //- @UseGmailConverationBreakerForExceptionReport -//
        /// <summary>
        /// Gets a value indicating whether to use gmail converation breaker.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if use gmail converation breaker; otherwise, <c>false</c>.
        /// </value>
        public static Boolean UseGmailConverationBreakerForExceptionReport
        {
            get
            {
                return Parser.ParseBoolean(GetParameter("UseGmailConverationBreakerForExceptionReport"), false);
            }
        }

        //+
        //- @GetParameter -//
        private static String GetParameter(String name)
        {
            return Section.EmailSetup.GetParameterValue(name);
        }
        //- @GetParameterOrDefault -//
        private static String GetParameterOrDefault(String name, String defaultValue)
        {
            return Parser.ParseString(GetParameter(name), defaultValue);
        }
    }
}