#region Copyright

//+ Copyright © David Betz 2008-2013

#endregion

using System;

namespace Nalarium
{
    public static class UnixDateTimeConverter
    {
        //- @ConvertFromUnixTimestamp -//
        /// <summary>
        ///     Converts from unix timestamp.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <returns></returns>
        public static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            //+
            return origin.AddSeconds(timestamp);
        }

        //- @ConvertToUnixTimestamp -//
        /// <summary>
        ///     Converts to unix timestamp.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static double ConvertToUnixTimestamp(DateTime date)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var diff = date - origin;
            //+
            return Math.Floor(diff.TotalSeconds);
        }
    }
}