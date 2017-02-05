#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System.Globalization;

namespace Nalarium.Reporting.ReportCreator.Formatter
{
    public class WikiFormatter : Formatter
    {
        //- @Ctor -//
        /// <summary>
        ///     Initializes a new instance of the <see cref="WikiFormatter" /> class.
        /// </summary>
        public WikiFormatter()
        {
            PreferredContentType = "text/plain";
        }

        //+
        //- @FormatMainHeading -//
        /// <summary>
        ///     Formats the main heading.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected override string FormatMainHeading(string text, StyleTypes styles)
        {
            return "=" + text + "=" + NewLine;
        }

        //- @FormatHeading -//
        /// <summary>
        ///     Formats the heading.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected override string FormatHeading(string text, StyleTypes styles)
        {
            return "==" + text + "==" + NewLine;
        }

        //- @FormatSubHeading -//
        /// <summary>
        ///     Formats the sub heading.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected override string FormatSubHeading(string text, StyleTypes styles)
        {
            return "===" + text + "===" + NewLine;
        }

        //- @FormatNormal -//
        /// <summary>
        ///     Formats the normal.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected override string FormatNormal(string text, StyleTypes styles)
        {
            var result = text;
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
        ///     Formats the break.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        protected override string FormatBreak(string text)
        {
            return NewLine;
        }

        //- @FormatDictionaryBegin -//
        protected override string FormatDictionaryBegin(string text, StyleTypes styles)
        {
            return string.Empty;
        }

        //- @FormatDictionaryTerm -//
        /// <summary>
        ///     Formats the dictionary term.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected override string FormatDictionaryTerm(string text, StyleTypes styles)
        {
            return ";" + FormatNormal(text, styles);
        }

        //- @FormatDictionaryDefinition -//
        /// <summary>
        ///     Formats the dictionary definition.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected override string FormatDictionaryDefinition(string text, StyleTypes styles)
        {
            return ":" + text;
        }

        //- @FormatDictionaryEnd -//
        /// <summary>
        ///     Formats the dictionary end.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected override string FormatDictionaryEnd(string text, StyleTypes styles)
        {
            return string.Empty;
        }

        //- @FormatListBegin -//
        /// <summary>
        ///     Formats the list begin.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected override string FormatListBegin(string text, StyleTypes styles)
        {
            return string.Empty;
        }

        //- @FormatListItem -//
        /// <summary>
        ///     Formats the list item.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected override string FormatListItem(string text, StyleTypes styles)
        {
            return "*" + FormatNormal(text, styles);
        }

        //- @FormatListEnd -//
        /// <summary>
        ///     Formats the list end.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected override string FormatListEnd(string text, StyleTypes styles)
        {
            return string.Empty;
        }

        //- #FormatLink -//
        /// <summary>
        ///     Formats the link.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected override string FormatLink(string text, StyleTypes styles)
        {
            if (!string.IsNullOrEmpty(text))
            {
                if (text.Contains(","))
                {
                    var partArray = text.Split(',');
                    //+
                    return string.Format(CultureInfo.CurrentCulture, "[{0}|{1}]", partArray[0], partArray[1]);
                }
                return "[" + text + "]";
            }
            //+
            return string.Empty;
        }

        //- #FormatPreFormatted -//
        /// <summary>
        ///     Formats the pre formatted text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        protected override string FormatPreFormatted(string text)
        {
            return text;
        }
    }
}