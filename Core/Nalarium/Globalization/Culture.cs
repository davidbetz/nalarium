#region Copyright

//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010

#endregion

using System;
using System.Globalization;
using System.Threading;

namespace Nalarium.Globalization
{
    public static class Culture
    {
        //- @CurrentCulture -//
        /// <summary>
        /// Culture information used for internationalization (i.e. formatting numbers, dates, time, etc).
        /// </summary>
        public static CultureInfo CurrentCulture
        {
            get
            {
                return Thread.CurrentThread.CurrentCulture;
            }
        }

        //- @CurrentUICulture -//
        /// <summary>
        /// Culture information used for localization (e.g. resources).
        /// </summary>
        public static CultureInfo CurrentUICulture
        {
            get
            {
                return Thread.CurrentThread.CurrentUICulture;
            }
        }

        //- @DateTimeFormat -//
        /// <summary>
        /// DateTime formatter for current culture.
        /// </summary>
        public static DateTimeFormatInfo DateTimeFormat
        {
            get
            {
                return Thread.CurrentThread.CurrentCulture.DateTimeFormat;
            }
        }

        //- @TwoCharacterCultureCode -//
        /// <summary>
        /// Two character culture code for current culture (e.g. en, mx, de).
        /// </summary>
        public static String TwoCharacterCultureCode
        {
            get
            {
                return Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
            }
        }
    }
}