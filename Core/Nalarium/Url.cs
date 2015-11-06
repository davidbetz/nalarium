#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

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
        public static String Join(params String[] parameterArray)
        {
            if (parameterArray == null)
            {
                return string.Empty;
            }
            //+
            return Clean(String.Join("/", new List<string>(parameterArray.Select(p => Clean(p)).Where(p => !String.IsNullOrWhiteSpace(p)))));
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
            while (path.StartsWith("/", StringComparison.OrdinalIgnoreCase))
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
            while (path.EndsWith("/", StringComparison.OrdinalIgnoreCase))
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
            return path.Replace("\\", "/").Replace(":", string.Empty);
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

        /// <summary>
        /// Shifts a URL left; a/b/c/d -> b/c/d
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="count">number of places</param>
        /// <returns>fixed url</returns>
        public static string Shift(string url, int count = 1)
        {
            if (String.IsNullOrEmpty(url))
            {
                return String.Empty;
            }
            var partArray = Split(url);
            return string.Join("/", ArrayModifier.Shift<string>(partArray, count));
        }

        /// <summary>
        /// Shifts a URL right; a/b/c/d -> a/b/c
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="count">number of places</param>
        /// <returns>fixed url</returns>
        public static string Strip(string url, int count = 1)
        {
            if (String.IsNullOrEmpty(url))
            {
                return String.Empty;
            }
            var partArray = Split(url);
            return string.Join("/", ArrayModifier.Strip<string>(partArray, count));
        }

        //- @UrlPartArray -//
        /// <summary>
        /// Gets the URL part array.
        /// </summary>
        public static string[] GetUrlPartArray(string url)
        {
            if (String.IsNullOrEmpty(url))
            {
                return null;
            }
            return url.ToLower(CultureInfo.CurrentCulture).Split('/').Where(p => !String.IsNullOrEmpty(p)).ToArray();
        }

        /// <summary>
        /// Gets url part
        /// </summary>
        /// <param name="url"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static string GetPart(string url, Position position)
        {
            if (String.IsNullOrEmpty(url))
            {
                return null;
            }
            return Collection.GetArrayPart(GetUrlPartArray(url), position);
        }

        /// <summary>
        /// Gets url part
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static string GetPart(string[] array, Position position)
        {
            if(array== null)
            {
                return String.Empty;
            }
            return Collection.GetArrayPart(array, position);
        }
    }
}