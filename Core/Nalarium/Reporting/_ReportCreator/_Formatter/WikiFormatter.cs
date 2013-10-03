#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using System.Globalization;

namespace Nalarium.Reporting
{
    public class WikiFormatter : Formatter
    {
        //- @Ctor -//
        /// <summary>
        /// Initializes a new instance of the <see cref="WikiFormatter"/> class.
        /// </summary>
        public WikiFormatter()
        {
            PreferredContentType = "text/plain";
        }

        //+
        //- @FormatMainHeading -//
        /// <summary>
        /// Formats the main heading.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected override String FormatMainHeading(String text, StyleTypes styles)
        {
            return "=" + text + "=" + NewLine;
        }

        //- @FormatHeading -//
        /// <summary>
        /// Formats the heading.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected override String FormatHeading(String text, StyleTypes styles)
        {
            return "==" + text + "==" + NewLine;
        }

        //- @FormatSubHeading -//
        /// <summary>
        /// Formats the sub heading.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected override String FormatSubHeading(String text, StyleTypes styles)
        {
            return "===" + text + "===" + NewLine;
        }

        //- @FormatNormal -//
        /// <summary>
        /// Formats the normal.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected override String FormatNormal(String text, StyleTypes styles)
        {
            String result = text;
            if ((StyleTypes.Bold & styles) == StyleTypes.Bold)
            {
                result = "'''" + text + "'''";
            }
            if ((StyleTypes.Italic & styles) == StyleTypes.Italic)
            {
                result = "'''''" + text + "'''''";
            }
            //+
            return result + NewLine;
        }

        //- @FormatBreak -//
        /// <summary>
        /// Formats the break.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        protected override String FormatBreak(String text)
        {
            return NewLine;
        }

        //- @FormatDictionaryBegin -//
        protected override String FormatDictionaryBegin(string text, StyleTypes styles)
        {
            return String.Empty;
        }

        //- @FormatDictionaryTerm -//
        /// <summary>
        /// Formats the dictionary term.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected override String FormatDictionaryTerm(string text, StyleTypes styles)
        {
            return ";" + FormatNormal(text, styles);
        }

        //- @FormatDictionaryDefinition -//
        /// <summary>
        /// Formats the dictionary definition.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected override String FormatDictionaryDefinition(string text, StyleTypes styles)
        {
            return ":" + text;
        }

        //- @FormatDictionaryEnd -//
        /// <summary>
        /// Formats the dictionary end.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected override String FormatDictionaryEnd(string text, StyleTypes styles)
        {
            return String.Empty;
        }

        //- @FormatListBegin -//
        /// <summary>
        /// Formats the list begin.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected override String FormatListBegin(string text, StyleTypes styles)
        {
            return String.Empty;
        }

        //- @FormatListItem -//
        /// <summary>
        /// Formats the list item.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected override String FormatListItem(string text, StyleTypes styles)
        {
            return "*" + FormatNormal(text, styles);
        }

        //- @FormatListEnd -//
        /// <summary>
        /// Formats the list end.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected override String FormatListEnd(string text, StyleTypes styles)
        {
            return String.Empty;
        }

        //- #FormatLink -//
        /// <summary>
        /// Formats the link.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected override String FormatLink(String text, StyleTypes styles)
        {
            if (!String.IsNullOrEmpty(text))
            {
                if (text.Contains(","))
                {
                    String[] partArray = text.Split(',');
                    //+
                    return String.Format(CultureInfo.CurrentCulture, "[{0}|{1}]", partArray[0], partArray[1]);
                }
                else
                {
                    return "[" + text + "]";
                }
            }
            //+
            return String.Empty;
        }

        //- #FormatPreFormatted -//
        /// <summary>
        /// Formats the pre formatted text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        protected override String FormatPreFormatted(String text)
        {
            return text;
        }
    }
}