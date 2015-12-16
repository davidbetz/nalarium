#region Copyright

//+ Copyright © David Betz 2008-2013

#endregion

using System;
using System.Globalization;
using System.Text;

namespace Nalarium.Text
{
    /// <summary>
    ///     Manipulates text by setting the case to either PascalCasing or camelCasing.
    /// </summary>
    public static class Case
    {
        //- @GetPascalCase -//
        /// <summary>
        ///     Gets the pascal case.
        /// </summary>
        /// <param name="parameterArray">The parameter array.</param>
        /// <returns></returns>
        public static string GetPascalCase(params string[] parameterArray)
        {
            var builder = new StringBuilder();
            foreach (var text in parameterArray)
            {
                builder.Append(InternalGetPascalCase(text));
            }
            //+
            return builder.ToString();
        }

        //- @GetCamelCase -//
        /// <summary>
        ///     Gets the camel case.
        /// </summary>
        /// <param name="parameterArray">The parameter array.</param>
        /// <returns></returns>
        public static string GetCamelCase(params string[] parameterArray)
        {
            if (parameterArray != null && parameterArray.Length > 0)
            {
                var first = parameterArray[0].ToLower(CultureInfo.CurrentCulture);
                if (parameterArray.Length > 1)
                {
                    var destinationArray = new string[parameterArray.Length - 1];
                    Array.Copy(parameterArray, 1, destinationArray, 0, parameterArray.Length - 1);
                    //+
                    return first + GetPascalCase(destinationArray);
                }
                return first;
            }
            //+
            return string.Empty;
        }

        //+
        //- $InternalGetPascalCase -//
        /// <summary>
        ///     Internals the get pascal case.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        private static string InternalGetPascalCase(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                text = text.ToLower(CultureInfo.CurrentCulture);
                var first = text[0].ToString();
                //+
                return first.ToUpper(CultureInfo.CurrentCulture) + text.Substring(1, text.Length - 1);
            }
            //+
            return string.Empty;
        }
    }
}