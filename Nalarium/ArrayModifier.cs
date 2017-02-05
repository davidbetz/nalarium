#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System;

namespace Nalarium
{
    /// <summary>
    ///     Modifies and array by allowing shifting or stripping of elements.
    /// </summary>
    public static class ArrayModifier
    {
        //- @Shift -//
        /// <summary>
        ///     Shifts an array left by 1.
        /// </summary>
        /// <typeparam name="T">Type of the array.</typeparam>
        /// <param name="original">The array to shift left.</param>
        /// <returns>The shifted array or null if original array had one element.</returns>
        public static T[] Shift<T>(Array original)
        {
            return Shift<T>(original, 1);
        }

        /// <summary>
        ///     Shifts an array left by 1.
        /// </summary>
        /// <typeparam name="T">Type of the array.</typeparam>
        /// <param name="original">The array to shift left.</param>
        /// <param name="count">Number of places to shift the array left.</param>
        /// <returns>The shifted array or null if original array had one element.</returns>
        public static T[] Shift<T>(Array original, int count)
        {
            if (original.Length > 0)
            {
                var shifted = new T[original.Length - count];
                Array.Copy(original, count, shifted, 0, original.Length - count);
                //+
                return shifted;
            }
            return null;
        }

        //- @Strip -//
        /// <summary>
        ///     Strips one element off the array.
        /// </summary>
        /// <typeparam name="T">Type of the array.</typeparam>
        /// <param name="original">The array to strip left.</param>
        /// <returns>The striped array or null if original array had one element.</returns>
        public static T[] Strip<T>(Array original)
        {
            return Strip<T>(original, 1);
        }

        /// <summary>
        ///     Strips a certain number of elements off the array.
        /// </summary>
        /// <typeparam name="T">Type of the array.</typeparam>
        /// <param name="original">The array to strip left.</param>
        /// <param name="count">Number of places to strip the array left.</param>
        /// <returns>The striped array or null if original array had one element.</returns>
        public static T[] Strip<T>(Array original, int count)
        {
            if (original.Length > 0)
            {
                var shifted = new T[original.Length - count];
                Array.Copy(original, shifted, original.Length - count);
                //+
                return shifted;
            }
            return null;
        }
    }
}