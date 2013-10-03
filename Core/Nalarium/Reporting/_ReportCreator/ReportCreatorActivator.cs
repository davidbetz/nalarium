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
    internal static class ReportCreatorActivator
    {
        //- $Create -//
        internal static ReportCreator Create(String processorType, Map<String, ReportCreatorFactory> processorFactoryMap)
        {
            ReportCreator processor = null;
            if (processorType.Contains(","))
            {
                return ObjectCreator.CreateAs<ReportCreator>(processorType);
            }
            //+
            if (processor == null && processorFactoryMap != null)
            {
                List<ReportCreatorFactory> processorFactoryList = processorFactoryMap.GetValueList();
                foreach (ReportCreatorFactory factory in processorFactoryList)
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