#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System;
using System.Text;

namespace Nalarium
{
    /// <summary>
    ///     Creates locally unique identifiers
    /// </summary>
    public static class LuidCreator
    {
        //- @GetNewLuid -//
        /// <summary>
        ///     Gets a new locally unique identifier as a string
        /// </summary>
        /// <value>The new locally unique identifier as a string</value>
        public static string GetNewLuid()
        {
            return GetLuid().Replace("{", "").Replace("}", "");
        }

        //- @GetNewLuidByteArray -//
        /// <summary>
        ///     Gets a new locally unique identifier as a byte array
        /// </summary>
        /// <value>The new locally unique identifier as a byte array</value>
        public static byte[] GetNewLuidByteArray()
        {
            return Encoding.UTF8.GetBytes(GetLuid());
        }

        private static string GetLuid()
        {
            return Guid.NewGuid().ToString().Replace("{", "").Split('-')[0];
        }
    }
}