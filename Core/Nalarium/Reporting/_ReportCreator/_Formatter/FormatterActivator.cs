#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using System.Collections.Generic;
using System.Globalization;
using Nalarium.Activation;
//+

namespace Nalarium.Reporting
{
    internal static class FormatterActivator
    {
        //- $Create -//
        internal static Formatter Create(String processorType, Map<String, FormatterFactory> processorFactoryMap)
        {
            Formatter processor = null;
            if (processorType.Contains(","))
            {
                return ObjectCreator.CreateAs<Formatter>(processorType);
            }
            //+
            if (processor == null && processorFactoryMap != null)
            {
                List<FormatterFactory> processorFactoryList = processorFactoryMap.GetValueList();
                foreach (FormatterFactory factory in processorFactoryList)
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