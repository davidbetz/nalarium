#region Copyright

//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010

#endregion

using System;

namespace Nalarium.Reporting
{
    public class HtmlFormatter : Formatter
    {
        //- @Ctor -//
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlFormatter"/> class.
        /// </summary>
        public HtmlFormatter()
        {
            PreferredContentType = "text/html";
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
            return "<h1>" + text + "</h1>";
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
            return "<h2>" + text + "</h2>";
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
            return "<h3>" + text + "</h3>";
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
                result = "<strong>" + text + "<strong>";
            }
            if ((StyleTypes.Italic & styles) == StyleTypes.Italic)
            {
                result = "</em>" + text + "</em>";
            }
            //+
            return result;
        }

        //- @FormatBreak -//
        /// <summary>
        /// Formats the break.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        protected override String FormatBreak(String text)
        {
            return "<br />";
        }

        //- @FormatDictionaryBegin -//
        /// <summary>
        /// Formats the dictionary begin.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected override String FormatDictionaryBegin(string text, StyleTypes styles)
        {
            return "<dl>";
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
            return "<dt>" + FormatNormal(text, styles) + "</dt>";
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
            return "<dd>" + text + "</dd>";
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
            return "</dl>";
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
            return "<li>";
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
            return FormatNormal(text, styles);
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
            return "</li>";
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
                String link;
                String display;
                if (text.Contains(","))
                {
                    String[] partArray = text.Split(',');
                    link = partArray[0];
                    display = partArray[1];
                }
                else
                {
                    link = text;
                    display = text;
                }
                //+
                return @"<a href=""" + link + @""">" + display + "</a>";
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
            return @"<p style=""white-space:pre-wrap;"">" + text + "</p>";
        }
    }
}