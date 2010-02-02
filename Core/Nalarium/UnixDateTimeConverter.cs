#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright � Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
namespace Nalarium
{
    public static class UnixDateTimeConverter
    {
        //- @ConvertFromUnixTimestamp -//
        /// <summary>
        /// Converts from unix timestamp.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <returns></returns>
        public static DateTime ConvertFromUnixTimestamp(Double timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            //+
            return origin.AddSeconds(timestamp);
        }

        //- @ConvertToUnixTimestamp -//
        /// <summary>
        /// Converts to unix timestamp.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static Double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan diff = date - origin;
            //+
            return Math.Floor(diff.TotalSeconds);
        }
    }
}