#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System.Globalization;
using Nalarium.Activation;

//+

namespace Nalarium.Reporting.Sender
{
    internal static class SenderActivator
    {
        //- $Create -//
        internal static Sender Create(string processorType, Map<string, SenderFactory> processorFactoryMap)
        {
            Sender processor = null;
            if (processorType.Contains(","))
            {
                return ObjectCreator.CreateAs<Sender>(processorType);
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