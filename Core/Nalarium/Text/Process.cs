#region Copyright

//+ Jampad Technology, Inc. 2007-2015 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2008-2015

#endregion

using System;

namespace Nalarium.Text
{
    /// <summary>
    /// General text manipulation.
    /// </summary>
    public static class Process
    {
        /// <summary>
        /// Returns up to n-characters.
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="max">Character count</param>
        /// <returns></returns>
        public static String Max(string text, int max, bool useEllipsis = false, bool useHtmlEllipsis = true)
        {
            if (String.IsNullOrEmpty(text))
            {
                return string.Empty;
            }
            if (useEllipsis && max > 3)
            {
                if (text.Length > max - 3)
                {
                    return text.Substring(0, max - 3) + (useHtmlEllipsis ? "&hellip;" : "...");
                }
            }
            if (text.Length > max)
            {
                return text.Substring(0, max);
            }
            return text;
        }
    }
}