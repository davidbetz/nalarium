#region Copyright

//+ Copyright © David Betz 2008-2013

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nalarium.Globalization;
using Nalarium.Properties;

namespace Nalarium.Text
{
    /// <summary>
    ///     Splits text while respecting quotes and literals.
    /// </summary>
    public static class TextSplitter
    {
        //- @Split -//
        /// <summary>
        ///     Splits text.
        /// </summary>
        /// <param name="text">The text to split</param>
        /// <param name="delimiterArray">Array of text delimiters</param>
        /// <returns>Array of strings split from input text</returns>
        public static string[] Split(string text, params char[] delimiterArray)
        {
            return Split(text, QuoteTypes.Both, delimiterArray);
        }

        /// <summary>
        ///     Splits text.
        /// </summary>
        /// <param name="text">The text to split</param>
        /// <param name="delimiterArray">Array of text delimiters</param>
        /// <param name="allowedQuoteTypes">The type of quotes allowed</param>
        /// <returns>Array of strings split from input text</returns>
        public static string[] Split(string text, QuoteTypes allowedQuoteTypes, params char[] delimiterArray)
        {
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }
            if (delimiterArray == null || delimiterArray.Length == 0)
            {
                throw new ArgumentNullException(ResourceAccessor.GetString("Text_DelimiterRequired", AssemblyInfo.AssemblyName, Resource.ResourceManager));
            }
            //+
            return InternalSplit(text, allowedQuoteTypes, delimiterArray);
        }

        //- ~InternalSplit -//
        internal static string[] InternalSplit(string text, QuoteTypes allowedQuoteTypes, params char[] delimiterArray)
        {
            var splitResult = new List<string>();
            var builder = new StringBuilder();
            var inQuote = false;
            var isLiteral = false;
            foreach (var c in text)
            {
                if (IsQuote(c, allowedQuoteTypes))
                {
                    if (isLiteral)
                    {
                        builder.Append(c);
                        isLiteral = false;
                    }
                    else
                    {
                        inQuote = !inQuote;
                    }
                }
                else if (c == '\\')
                {
                    isLiteral = true;
                }
                else if (inQuote)
                {
                    builder.Append(c);
                }
                else if (delimiterArray.Contains(c))
                {
                    if (isLiteral)
                    {
                        builder.Append(c);
                        isLiteral = false;
                    }
                    else
                    {
                        splitResult.Add(builder.ToString());
                        builder = new StringBuilder();
                    }
                }
                else
                {
                    builder.Append(c);
                }
            }
            //+ flush
            if (builder.Length > 0)
            {
                splitResult.Add(builder.ToString());
            }
            //+
            return splitResult.ToArray();
        }

        //- $IsQuote -//
        private static bool IsQuote(char c, QuoteTypes allowedQuoteTypes)
        {
            switch (allowedQuoteTypes)
            {
                case QuoteTypes.Double:
                    return c == '"';
                case QuoteTypes.Single:
                    return c == '\'';
                case QuoteTypes.Both:
                    return c == '"' | c == '\'';
            }
            //+
            return false;
        }
    }
}