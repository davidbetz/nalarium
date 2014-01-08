#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using System.Collections.Generic;
using System.Globalization;
using Nalarium.Activation;

//+

namespace Nalarium.Reporting.Sender
{
    internal static class SenderActivator
    {
        //- $Create -//
        internal static Sender Create(String processorType, Map<String, SenderFactory> processorFactoryMap)
        {
            Sender processor = null;
            if (processorType.Contains(","))
            {
                return ObjectCreator.CreateAs<Sender>(processorType);
            }
            //+
            if (processor == null && processorFactoryMap != null)
            {
                List<SenderFactory> processorFactoryList = processorFactoryMap.GetValueList();
                foreach (SenderFactory factory in processorFactoryList)
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