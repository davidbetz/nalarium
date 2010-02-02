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
                    processorType = processorType.ToLower(System.Globalization.CultureInfo.CurrentCulture);
                    processor = (ReportCreator)factory.Create(processorType);
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