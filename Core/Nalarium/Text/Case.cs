#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
namespace Nalarium.Text
{
    /// <summary>
    /// Manipulates text by setting the case to either PascalCasing or camelCasing.
    /// </summary>
    public static class Case
    {
        //- @GetPascalCase -//
        /// <summary>
        /// Gets the pascal case.
        /// </summary>
        /// <param name="parameterArray">The parameter array.</param>
        /// <returns></returns>
        public static String GetPascalCase(params String[] parameterArray)
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            foreach (String text in parameterArray)
            {
                builder.Append(InternalGetPascalCase(text));
            }
            //+
            return builder.ToString();
        }

        //- @GetCamelCase -//
        /// <summary>
        /// Gets the camel case.
        /// </summary>
        /// <param name="parameterArray">The parameter array.</param>
        /// <returns></returns>
        public static String GetCamelCase(params String[] parameterArray)
        {
            if (parameterArray != null && parameterArray.Length > 0)
            {
                String first = parameterArray[0].ToLower(System.Globalization.CultureInfo.CurrentCulture);
                if (parameterArray.Length > 1)
                {
                    String[] destinationArray = new String[parameterArray.Length - 1];
                    Array.Copy(parameterArray, 1, destinationArray, 0, parameterArray.Length - 1);
                    //+
                    return first + GetPascalCase(destinationArray);
                }
                else
                {
                    return first;
                }
            }
            //+
            return String.Empty;
        }

        //+
        //- $InternalGetPascalCase -//
        /// <summary>
        /// Internals the get pascal case.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        private static String InternalGetPascalCase(String text)
        {
            if (!String.IsNullOrEmpty(text))
            {
                text = text.ToLower(System.Globalization.CultureInfo.CurrentCulture);
                String first = text[0].ToString();
                //+
                return first.ToUpper(System.Globalization.CultureInfo.CurrentCulture) + text.Substring(1, text.Length - 1);
            }
            //+
            return String.Empty;
        }
    }
}