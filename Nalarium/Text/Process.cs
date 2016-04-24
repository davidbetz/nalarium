#region Copyright

//+ Copyright © David Betz 2008-2015

#endregion

namespace Nalarium.Text
{
    /// <summary>
    ///     General text manipulation.
    /// </summary>
    public static class Process
    {
        /// <summary>
        ///     Returns up to n-characters.
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="max">Character count</param>
        /// <param name="useEllipsis"></param>
        /// <param name="useHtmlEllipsis"></param>
        /// <returns></returns>
        public static string Max(string text, int max, bool useEllipsis = false, bool useHtmlEllipsis = false)
        {
            if (string.IsNullOrEmpty(text))
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