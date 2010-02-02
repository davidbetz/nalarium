#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
using Nalarium.Configuration;
using Nalarium.Reporting;
//+
namespace Nalarium.Activation
{
    public static class InjectionData
    {
        private static Object _lock = new Object();

        //+
        private static Type _int32Type = typeof(System.Int32);
        private static Type _doubleType = typeof(System.Double);
        private static Type _booleanType = typeof(System.Boolean);
        private static Type _stringType = typeof(System.String);

        //- $Map -//
        private static StringObjectMap Map { get; set; }

        //+
        //- @Ctor -//
        static InjectionData()
        {
            Reporter reporter = ReportController.GetReporter(ObjectInjectionReportController.CoreInjectionDebugReporter);
            if (reporter.Initialized)
            {
                reporter.ReportCreator = new MapReportCreator();
            }
            //+
            InitObjectMap();
        }

        //- @GetObject -//
        public static Object GetObject(String name)
        {
            lock (_lock)
            {
                if (Map.ContainsKey(name))
                {
                    return Map[name];
                }
                //+
                return null;
            }
        }
        public static T GetObject<T>(String name)
        {
            lock (_lock)
            {
                if (Map.ContainsKey(name) && Map[name] is T)
                {
                    return (T)Map[name];
                }
                //+
                return default(T);
            }
        }

        //+
        //- $InitObjectMap -//
        private static void InitObjectMap()
        {
            Map = new StringObjectMap();
            foreach (ObjectElement element in SystemSection.GetConfigSection().Objects)
            {
                try
                {
                    lock (_lock)
                    {
                        Object obj = InjectedObjectActivator.Create(element.Type, FactoryCache.ObjectFactoryCache);
                        if (obj != null)
                        {
                            String name = GetShorterName(obj.GetType(), element.Name);
                            Map.Add(name, obj);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ObjectInjectionReportController.Reporter.Initialized)
                    {
                        Map map = new Map();
                        map.Add("Section", "Object Injector");
                        map.Add("Type", element.Type);
                        map.Add("Message", ex.Message);
                        map.Add("Exception Type", ex.GetType().FullName);
                        //+
                        ObjectInjectionReportController.Reporter.AddMap(map);
                    }
                }
            }
            //+ first send
            if (ObjectInjectionReportController.Reporter.Initialized)
            {
                Boolean hasDataToSend = ObjectInjectionReportController.Reporter.HasDataToSend;
                if (hasDataToSend)
                {
                    String name = Nalarium.Configuration.SystemSection.GetConfigSection().AppInfo.Name;
                    if (!String.IsNullOrEmpty(name))
                    {
                        Map map = new Map();
                        map.Add("App Name", name);
                        ObjectInjectionReportController.Reporter.InsertMap(map, 0);
                    }
                    ObjectInjectionReportController.Reporter.Send(true);
                    ObjectInjectionReportController.Reporter.ReportCreator.Clear();
                }
            }
        }

        //- $GetShorterName -//
        private static string GetShorterName(Type objType, String name)
        {
            if (objType == _int32Type)
            {
                return "Int32";
            }
            else if (objType == _doubleType)
            {
                return "Double";
            }
            else if (objType == _booleanType)
            {
                return "Boolean";
            }
            else if (objType == _stringType)
            {
                return "String";
            }
            //+
            return name;
        }
    }
}