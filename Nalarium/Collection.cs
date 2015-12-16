#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System.Collections;

namespace Nalarium
{
    /// <summary>
    ///     Provides testing and interaction of collections.
    /// </summary>
    public static class Collection
    {
        //- @IsNullOrEmpty -//
        /// <summary>
        ///     Determines whether a list is null or empty.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>true if the list is null or empty; otherwise, false.</returns>
        public static bool IsNullOrEmpty(IList list)
        {
            if (list == null || list.Count == 0)
            {
                return true;
            }
            //+
            return false;
        }

        /// <summary>
        ///     Determines whether a collection is null or empty.
        /// </summary>
        /// <param name="list">The collection.</param>
        /// <returns>true if the collection is null or empty; otherwise, false.</returns>
        public static bool IsNullOrEmpty(ICollection collection)
        {
            if (collection == null || collection.Count == 0)
            {
                return true;
            }
            //+
            return false;
        }

        /// <summary>
        ///     Determines whether an array is null or empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The array.</param>
        /// <returns>true if the array is null or empty; otherwise, false.</returns>
        public static bool IsNullOrEmpty<T>(T[] array)
        {
            if (array == null || array.Length == 0)
            {
                return true;
            }
            //+
            return false;
        }

        //- @IsNullOrTooSmall -//
        /// <summary>
        ///     Determines whether a list is null or too small,.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="minimum">The minimum.</param>
        /// <returns>true if the list is null or too small; otherwise, false.</returns>
        public static bool IsNullOrTooSmall(IList list, int minimum)
        {
            if (list == null || list.Count < minimum)
            {
                return true;
            }
            //+
            return false;
        }

        /// <summary>
        ///     Determines whether a collection is null or too small,.
        /// </summary>
        /// <param name="list">The collection.</param>
        /// <param name="minimum">The minimum.</param>
        /// <returns>true if the collection is null or too small; otherwise, false.</returns>
        public static bool IsNullOrTooSmall(ICollection collection, int minimum)
        {
            if (collection == null || collection.Count < minimum)
            {
                return true;
            }
            //+
            return false;
        }

        /// <summary>
        ///     Determines whether an array is null or too small,.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The array.</param>
        /// <param name="minimum">The minimum.</param>
        /// <returns>true if the collection is null or too small; otherwise, false.</returns>
        public static bool IsNullOrTooSmall<T>(T[] array, int minimum)
        {
            if (array == null || array.Length < minimum)
            {
                return true;
            }
            //+
            return false;
        }

        //- @GetArrayPart -//
        /// <summary>
        ///     Gets a particular part of an array.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>The requested part of the URL</returns>
        public static T GetArrayPart<T>(T[] array, Position position)
        {
            if (!IsNullOrEmpty(array))
            {
                switch (position)
                {
                    case Position.First:
                        return array[0];
                    case Position.Second:
                        if (array.Length > 1)
                        {
                            return array[1];
                        }
                        break;
                    case Position.Third:
                        if (array.Length > 2)
                        {
                            return array[2];
                        }
                        break;
                    case Position.Ultima:
                        return array[array.Length - 1];
                    case Position.Penultima:
                        if (array.Length > 1)
                        {
                            return array[array.Length - 2];
                        }
                        break;
                    case Position.Antepenultima:
                        if (array.Length > 2)
                        {
                            return array[array.Length - 3];
                        }
                        break;
                }
            }
            //+
            return default(T);
        }
    }
}