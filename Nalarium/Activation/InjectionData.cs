#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System;
using Nalarium.Configuration.AppConfig;
using Nalarium.Reporting;
using Nalarium.Reporting.ReportCreator;

namespace Nalarium.Activation
{
    public static class InjectionData
    {
        private static readonly object _lock = new object();

        //+
        private static readonly Type _int32Type = typeof (int);
        private static readonly Type _doubleType = typeof (double);
        private static readonly Type _booleanType = typeof (bool);
        private static readonly Type _stringType = typeof (string);

        //- $Map -//

        //+
        //- @Ctor -//
        static InjectionData()
        {
            var reporter = ReportController.GetReporter(ObjectInjectionReportController.CoreInjectionDebugReporter);
            if (reporter.Initialized)
            {
                reporter.ReportCreator = new MapReportCreator();
            }
            //+
            InitObjectMap();
        }

        private static StringObjectMap Map { get; set; }

        //- @GetObject -//
        public static object GetObject(string name)
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

        public static T GetObject<T>(string name)
        {
            lock (_lock)
            {
                if (Map.ContainsKey(name) && Map[name] is T)
                {
                    return (T) Map[name];
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
            foreach (var element in SystemSection.GetConfigSection().Objects)
            {
                try
                {
                    lock (_lock)
                    {
                        var obj = InjectedObjectActivator.Create(element.Type, FactoryCache.ObjectFactoryCache);
                        if (obj != null)
                        {
                            var name = GetShorterName(obj.GetType(), element.Name);
                            Map.Add(name, obj);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ObjectInjectionReportController.Reporter.Initialized)
                    {
                        var map = new Map();
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
                var hasDataToSend = ObjectInjectionReportController.Reporter.HasDataToSend;
                if (hasDataToSend)
                {
                    var name = SystemSection.GetConfigSection().AppInfo.Name;
                    if (!string.IsNullOrEmpty(name))
                    {
                        var map = new Map();
                        map.Add("App Name", name);
                        ObjectInjectionReportController.Reporter.InsertMap(map, 0);
                    }
                    ObjectInjectionReportController.Reporter.Send(true);
                    ObjectInjectionReportController.Reporter.ReportCreator.Clear();
                }
            }
        }

        //- $GetShorterName -//
        private static string GetShorterName(Type objType, string name)
        {
            if (objType == _int32Type)
            {
                return "Int32";
            }
            if (objType == _doubleType)
            {
                return "Double";
            }
            if (objType == _booleanType)
            {
                return "Boolean";
            }
            if (objType == _stringType)
            {
                return "String";
            }
            //+
            return name;
        }
    }
}