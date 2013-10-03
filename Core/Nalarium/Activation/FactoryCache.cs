#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using Nalarium.Configuration;
//+

namespace Nalarium.Activation
{
    public static class FactoryCache
    {
        private static readonly Object _lock = new Object();

        //+
        public static Map<String, IFactory> ObjectFactoryCache = new Map<String, IFactory>();
        public static Map<String, IFactory> TypeFactoryCache = new Map<String, IFactory>();

        //- @Ctor -//
        static FactoryCache()
        {
            TypeFactoryCache.Add("BasicTypeObjectFactory", new BasicTypeObjectFactory());
            //+
            LoadFactoryData();
        }

        internal static void LoadFactoryData()
        {
            SystemSection section = SystemSection.GetConfigSection();
            if (section != null)
            {
                List<FactoryElement> elementList = section.Reporting.Factories.OrderBy(p => p.Priority).ToList();
                foreach (FactoryElement processorData in elementList)
                {
                    RegisterFactory(processorData.FactoryType);
                }
            }
        }

        //- @RegisterFactory -//
        public static void RegisterFactory(String factoryType)
        {
            lock (_lock)
            {
                if (!ObjectFactoryCache.ContainsKey(factoryType))
                {
                    var factory = ObjectCreator.CreateAs<IFactory>(factoryType);
                    if (factory != null)
                    {
                        if (factory is ObjectFactory)
                        {
                            ObjectFactoryCache.Add(factoryType, factory);
                        }
                        else if (factory is TypeFactory)
                        {
                            TypeFactoryCache.Add(factoryType, factory);
                        }
                    }
                }
            }
        }
    }
}