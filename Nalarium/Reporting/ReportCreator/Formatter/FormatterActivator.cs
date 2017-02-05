#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System.Globalization;
using Nalarium.Activation;

//+

namespace Nalarium.Reporting.ReportCreator.Formatter
{
    internal static class FormatterActivator
    {
        //- $Create -//
        internal static Formatter Create(string processorType, Map<string, FormatterFactory> processorFactoryMap)
        {
            Formatter processor = null;
            if (processorType.Contains(","))
            {
                return ObjectCreator.CreateAs<Formatter>(processorType);
            }
            //+
            if (processor == null && processorFactoryMap != null)
            {
                var processorFactoryList = processorFactoryMap.GetValueList();
                foreach (var factory in processorFactoryList)
                {
                    processorType = processorType.ToLower(CultureInfo.CurrentCulture);
                    processor = factory.Create(processorType);
                    if (processor != null)
                    {
                        break;
                    }
                }
            }
            //+
            return processor;
        }
    }
}