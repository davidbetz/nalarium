#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2008-2013

#endregion

using System;

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
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
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
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan diff = date - origin;
            //+
            return Math.Floor(diff.TotalSeconds);
        }
    }
}