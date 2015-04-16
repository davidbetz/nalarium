#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;

namespace Nalarium
{
    /// <summary>
    /// Manages a Url
    /// </summary>
    public static class Url
    {
        //- @Join -//
        /// <summary>
        /// Cleanly joins two paths.
        /// </summary>
        /// <param name="path1">The first path.</param>
        /// <param name="path2">The second path.</param>
        /// <returns>The merged path.</returns>
        public static String Join(String path1, String path2)
        {
            if (String.IsNullOrEmpty(path1))
            {
                return path2;
            }
            if (String.IsNullOrEmpty(path2))
            {
                return path1;
            }
            //+
            return Clean(path1) + "/" + Clean(path2);
        }

        //- @FixUrl -//
        /// <summary>
        /// Removes slashes from the beginning and end of a path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>The fixed path.</returns>
        public static String Clean(String path)
        {
            return CleanHead(CleanTail(path));
        }

        //- @CleanHead -//
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
            if (path.StartsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                path = path.Substring(1, path.Length - 1);
            }
            //+
            return path;
        }

        //- @CleanTail -//
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
            if (path.EndsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                path = path.Substring(0, path.Length - 1);
            }
            //+
            return path;
        }

        //- @RemoveEndingQuestionMark -//
        /// <summary>
        /// Removes the ending question mark of a path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns> without question mark.</returns>
        public static String RemoveEndingQuestionMark(String path)
        {
            if (String.IsNullOrEmpty(path))
            {
                return String.Empty;
            }
            Int32 index = path.IndexOf("?");
            if (index > -1)
            {
                path = path.Substring(0, index);
            }
            //+
            return path;
        }

        /// <summary>
        /// Converts a \ path into a / relative url.
        /// </summary>
        /// <param name="path">Windows-style path</param>
        /// <returns>Internet-style relative url</returns>
        public static String FromPath(string path)
        {
            if (String.IsNullOrEmpty(path))
            {
                return String.Empty;
            }
            //+
            return path.Replace("\\", "/");
        }

        /// <summary>
        /// Splits a url into a string array; paths are converted into urls.
        /// 
        ///     Use Nalarum.Collection.GetArrayPart to get a specific part.
        ///     
        /// </summary>
        /// <param name="url">Url</param>
        /// <returns>url part array</returns>
        public static string[] Split(string url)
        {
            if (String.IsNullOrEmpty(url))
            {
                return new string[] { };
            }
            url = Clean(FromPath(url));
            //+
            return url.Split('/');
        }
    }
}