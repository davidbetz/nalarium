#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
using System.Linq;
//+
using Nalarium.Configuration;
//+
namespace Nalarium.Activation
{
    public static class FactoryCache
    {
        private static Object _lock = new Object();

        //+
        public static Map<String, IFactory> ObjectFactoryCache = new Map<String, IFactory>();
        public static Map<String, IFactory> TypeFactoryCache = new Map<String, IFactory>();

        //- @Ctor -//
        static FactoryCache()
        {
            TypeFactoryCache.Add("BasicTypeObjectFactory", new Nalarium.Activation.BasicTypeObjectFactory());
            //+
            LoadFactoryData();
        }

        internal static void LoadFactoryData()
        {
            Nalarium.Configuration.SystemSection section = Nalarium.Configuration.SystemSection.GetConfigSection();
            if (section != null)
            {
                System.Collections.Generic.List<FactoryElement> elementList = section.Reporting.Factories.OrderBy(p => p.Priority).ToList();
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
                    IFactory factory = ObjectCreator.CreateAs<IFactory>(factoryType);
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