#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

//+
namespace Nalarium.Reporting.ReportCreator.Formatter
{
    public enum FormatterType
    {
        MainHeading,
        Heading,
        SubHeading,
        Normal,
        Break,
        DictionaryBegin,
        DictionaryTerm,
        DictionaryDefinition,
        DictionaryEnd,
        ListBegin,
        ListItem,
        ListEnd,
        Link,
        PreFormatted
    }
}