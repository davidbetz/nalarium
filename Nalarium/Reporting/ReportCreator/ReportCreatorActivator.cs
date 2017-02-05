#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System.Globalization;
using Nalarium.Activation;

//+

namespace Nalarium.Reporting.ReportCreator
{
    internal static class ReportCreatorActivator
    {
        //- $Create -//
        internal static ReportCreator Create(string processorType, Map<string, ReportCreatorFactory> processorFactoryMap)
        {
            ReportCreator processor = null;
            if (processorType.Contains(","))
            {
                return ObjectCreator.CreateAs<ReportCreator>(processorType);
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