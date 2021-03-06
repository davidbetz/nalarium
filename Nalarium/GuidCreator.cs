#region Copyright

//+ Copyright � David Betz 2007-2017

#endregion

using System;

namespace Nalarium
{
    /// <summary>
    ///     Creates guids in various formats.
    /// </summary>
    public static class GuidCreator
    {
        //- @GetGuidObject -//
        /// <summary>
        ///     Gets a new GUID.
        /// </summary>
        /// <value>The new GUID.</value>
        public static Guid GetGuidObject()
        {
            return Guid.NewGuid();
        }

        //- @GetNewGuid -//
        /// <summary>
        ///     Gets a new GUID as a string
        /// </summary>
        /// <value>The new GUID as a string</value>
        public static string GetNewGuid()
        {
            return GetGuidObject().ToString().Replace("{", "").Replace("}", "");
        }

        //- @GetNewGuidByteArray -//
        /// <summary>
        ///     Gets a new GUID as a byte array
        /// </summary>
        /// <value>The new GUID as a byte array</value>
        public static byte[] GetNewGuidByteArray()
        {
            return GetGuidObject().ToByteArray();
        }
    }
}