#region Copyright

//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010

#endregion

using System;

namespace Nalarium.Reporting
{
    public abstract class Formatter
    {
        public const String NewLine = "\r\n";

        //+
        //- @PreferredContentType -//
        /// <summary>
        /// Gets or sets the type of the preferred content.
        /// </summary>
        /// <value>The type of the preferred content.</value>
        public String PreferredContentType { get; set; }

        //+
        //- @Format -//
        /// <summary>
        /// Formats the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="formatterType">Type of the formatter.</param>
        /// <returns></returns>
        public String Format(String text, FormatterType formatterType)
        {
            return Format(text, formatterType, StyleTypes.None);
        }

        /// <summary>
        /// Formats the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="formatterType">Type of the formatter.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        public String Format(String text, FormatterType formatterType, StyleTypes styles)
        {
            switch (formatterType)
            {
                case FormatterType.MainHeading:
                    return FormatMainHeading(text, styles);
                case FormatterType.Heading:
                    return FormatHeading(text, styles);
                case FormatterType.SubHeading:
                    return FormatSubHeading(text, styles);
                case FormatterType.Normal:
                    return FormatNormal(text, styles);
                case FormatterType.Break:
                    return FormatBreak(text);
                case FormatterType.ListBegin:
                    return FormatListBegin(text, styles);
                case FormatterType.ListItem:
                    return FormatListItem(text, styles);
                case FormatterType.ListEnd:
                    return FormatListEnd(text, styles);
                case FormatterType.DictionaryBegin:
                    return FormatDictionaryBegin(text, styles);
                case FormatterType.DictionaryTerm:
                    return FormatDictionaryTerm(text, styles);
                case FormatterType.DictionaryDefinition:
                    return FormatDictionaryDefinition(text, styles);
                case FormatterType.DictionaryEnd:
                    return FormatDictionaryEnd(text, styles);
                case FormatterType.Link:
                    return FormatLink(text, styles);
                case FormatterType.PreFormatted:
                    return FormatPreFormatted(text);
                default:
                    return text;
            }
        }

        //- #FormatMainHeading -//
        /// <summary>
        /// Formats the main heading.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected abstract String FormatMainHeading(String text, StyleTypes styles);

        //- #FormatHeading -//
        /// <summary>
        /// Formats the heading.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected abstract String FormatHeading(String text, StyleTypes styles);

        //- #FormatSubHeading -//
        /// <summary>
        /// Formats the sub heading.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected abstract String FormatSubHeading(String text, StyleTypes styles);

        //- #FormatNormal -//
        /// <summary>
        /// Formats the normal.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected abstract String FormatNormal(String text, StyleTypes styles);

        //- #FormatBreak -//
        /// <summary>
        /// Formats the break.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        protected abstract String FormatBreak(String text);

        //- #FormatDictionaryBegin -//
        /// <summary>
        /// Formats the dictionary begin.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected abstract String FormatDictionaryBegin(String text, StyleTypes styles);

        //- #FormatDictionaryTerm -//
        /// <summary>
        /// Formats the dictionary term.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected abstract String FormatDictionaryTerm(String text, StyleTypes styles);

        //- #FormatDictionaryDefinition -//
        /// <summary>
        /// Formats the dictionary definition.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected abstract String FormatDictionaryDefinition(String text, StyleTypes styles);

        //- #FormatDictionaryEnd -//
        /// <summary>
        /// Formats the dictionary end.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected abstract String FormatDictionaryEnd(String text, StyleTypes styles);

        //- #FormatListBegin -//
        /// <summary>
        /// Formats the list begin.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected abstract String FormatListBegin(String text, StyleTypes styles);

        //- #FormatListItem -//
        /// <summary>
        /// Formats the list item.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected abstract String FormatListItem(String text, StyleTypes styles);

        //- #FormatListEnd -//
        /// <summary>
        /// Formats the list end.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected abstract String FormatListEnd(String text, StyleTypes styles);

        //- #FormatLink -//
        /// <summary>
        /// Formats the link.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        protected abstract String FormatLink(string text, StyleTypes styles);

        //- #FormatPreFormatted -//
        /// <summary>
        /// Formats the pre formatted text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        protected abstract String FormatPreFormatted(String text);
    }
}