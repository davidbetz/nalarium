﻿#region Copyright
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
                    processorType = processorType.ToLower(System.Globalization.CultureInfo.CurrentCulture);
                    processor = (Sender)factory.Create(processorType);
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