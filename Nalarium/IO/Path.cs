#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;

namespace Nalarium.IO
{
    /// <summary>
    /// Manages a Path.
    /// </summary>
    public static class Path
    {
        //- @CleanPath -//
        /// <summary>
        /// Removes slashes from the beginning and end of a path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>The fixed path.</returns>
        public static String Clean(String path)
        {
            return CleanHead(CleanTail(path));
        }

        //- @CleanPathHead -//
        /// <summary>
        /// Removes slashes from the beginning of a path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>The fixed path.</returns>
        public static String CleanHead(String path)
        {
            if (String.IsNullOrEmpty(path))
            {
                return String.Empty;
            }
            if (path.StartsWith("\\", StringComparison.OrdinalIgnoreCase))
            {
                path = path.Substring(1, path.Length - 1);
            }
            //+
            return path;
        }

        //- @CleanPathTail -//
        /// <summary>
        /// Removes slashes from the end of a path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>The fixed path.</returns>
        public static String CleanTail(String path)
        {
            if (String.IsNullOrEmpty(path))
            {
                return String.Empty;
            }
            if (path.EndsWith("\\", StringComparison.OrdinalIgnoreCase))
            {
                path = path.Substring(0, path.Length - 1);
            }
            //+
            return path;
        }
    }
}