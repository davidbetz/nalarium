#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
using System.Collections.Generic;
//+
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
                    processorType = processorType.ToLower(System.Globalization.CultureInfo.CurrentCulture);
                    processor = (Formatter)factory.Create(processorType);
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