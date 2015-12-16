#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System.Linq;
using Nalarium.Configuration.AppConfig;
//+

namespace Nalarium.Activation
{
    public static class FactoryCache
    {
        private static readonly object _lock = new object();

        //+
        public static Map<string, IFactory> ObjectFactoryCache = new Map<string, IFactory>();
        public static Map<string, IFactory> TypeFactoryCache = new Map<string, IFactory>();

        //- @Ctor -//
        static FactoryCache()
        {
            TypeFactoryCache.Add("BasicTypeObjectFactory", new BasicTypeObjectFactory());
            //+
            LoadFactoryData();
        }

        internal static void LoadFactoryData()
        {
            var section = SystemSection.GetConfigSection();
            if (section != null)
            {
                var elementList = section.Reporting.Factories.OrderBy(p => p.Priority).ToList();
                foreach (var processorData in elementList)
                {
                    RegisterFactory(processorData.FactoryType);
                }
            }
        }

        //- @RegisterFactory -//
        public static void RegisterFactory(string factoryType)
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