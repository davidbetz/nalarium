#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System.Linq;
using System.Threading;
using Nalarium.Activation;
using Nalarium.Configuration.AppConfig;
using Nalarium.Reporting.ReportCreator;
using Nalarium.Reporting.ReportCreator.Formatter;
using Nalarium.Reporting.Sender;
//+

namespace Nalarium.Reporting
{
    public static class ReportController
    {
        private static readonly ReaderWriterLockSlim readerWriterLockSlim = new ReaderWriterLockSlim();
        private static readonly object _lock = new object();

        //+
        internal static Map<string, ReportCreator.ReportCreator> ReportCreatorCache = new Map<string, ReportCreator.ReportCreator>();
        internal static Map<string, Sender.Sender> SenderCache = new Map<string, Sender.Sender>();
        internal static Map<string, Formatter> FormatterCache = new Map<string, Formatter>();
        //+
        internal static Map<string, ReportCreatorFactory> ReportCreatorFactoryCache = new Map<string, ReportCreatorFactory>();
        internal static Map<string, SenderFactory> SenderFactoryCache = new Map<string, SenderFactory>();
        internal static Map<string, FormatterFactory> FormatterFactoryCache = new Map<string, FormatterFactory>();

        //+
        //- $ReporterMap -//
        private static readonly Map<string, Reporter> ReporterMap = new Map<string, Reporter>();

        //+
        //- @Ctor -//
        static ReportController()
        {
            ReportCreatorFactoryCache.Add("David Betz 2007-2017.Reporting.CommonReportCreatorFactory, David Betz 2007-2017", new CommonReportCreatorFactory());
            SenderFactoryCache.Add("David Betz 2007-2017.Reporting.CommonSenderFactory, David Betz 2007-2017", new CommonSenderFactory());
            FormatterFactoryCache.Add("David Betz 2007-2017.Reporting.CommonFormatterFactory, David Betz 2007-2017", new CommonFormatterFactory());
            //+
            InitFactoryData();
            InitReporterData();
        }

        //+
        //- @GetReporter -//
        /// <summary>
        ///     Gets the reporter.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static Reporter GetReporter(string name)
        {
            lock (_lock)
            {
                if (ReporterMap.ContainsKey(name))
                {
                    var reporter = ReporterMap[name];
                    reporter.Initialized = true;
                    //+
                    return reporter;
                }
                //+
                return new Reporter();
            }
        }

        //- @RegisterFactory -//
        /// <summary>
        ///     Registers the factory.
        /// </summary>
        /// <param name="factoryType">The type.</param>
        public static void RegisterFactory(string factoryType)
        {
            try
            {
                Factory factory = null;
                //+
                readerWriterLockSlim.EnterUpgradeableReadLock();
                if (!SenderFactoryCache.ContainsKey(factoryType) && !FormatterFactoryCache.ContainsKey(factoryType) && !ReportCreatorFactoryCache.ContainsKey(factoryType))
                {
                    readerWriterLockSlim.EnterWriteLock();
                    //+
                    try
                    {
                        if (!SenderFactoryCache.ContainsKey(factoryType) && !FormatterFactoryCache.ContainsKey(factoryType) && !ReportCreatorFactoryCache.ContainsKey(factoryType))
                        {
                            factory = ObjectCreator.CreateAs<Factory>(factoryType);
                            if (factory != null)
                            {
                                if (factory is SenderFactory)
                                {
                                    SenderFactoryCache.Add(factoryType, (SenderFactory) factory);
                                }
                                else if (factory is FormatterFactory)
                                {
                                    FormatterFactoryCache.Add(factoryType, (FormatterFactory) factory);
                                }
                                else if (factory is ReportCreatorFactory)
                                {
                                    ReportCreatorFactoryCache.Add(factoryType, (ReportCreatorFactory) factory);
                                }
                            }
                        }
                    }
                    finally
                    {
                        readerWriterLockSlim.ExitWriteLock();
                    }
                }
            }
            finally
            {
                readerWriterLockSlim.ExitUpgradeableReadLock();
            }
        }

        //- @Create -//
        /// <summary>
        ///     Creates the specified report creator type.
        /// </summary>
        /// <param name="reportCreatorType">Type of the report creator.</param>
        /// <param name="senderType">Type of the sender.</param>
        /// <param name="formatterType">Type of the formatter.</param>
        /// <returns></returns>
        public static Reporter Create(string reportCreatorType, string senderType, string formatterType)
        {
            return Create(string.Empty, reportCreatorType, senderType, formatterType);
        }

        /// <summary>
        ///     Creates the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="reportCreatorType">Type of the report creator.</param>
        /// <param name="senderType">Type of the sender.</param>
        /// <param name="formatterType">Type of the formatter.</param>
        /// <returns></returns>
        public static Reporter Create(string name, string reportCreatorType, string senderType, string formatterType)
        {
            var creator = CreateReportCreator(reportCreatorType);
            var sender = CreateSender(senderType);
            var formatter = CreateFormatter(formatterType);
            //+
            lock (_lock)
            {
                var reporter = Reporter.Create(name, creator, sender, formatter);
                if (!string.IsNullOrEmpty(name))
                {
                    ReporterMap.Add(name, reporter);
                }
                //+
                return reporter;
            }
        }

        //- $InitFactoryData -//
        private static void InitFactoryData()
        {
            var section = SystemSection.GetConfigSection();
            if (section != null)
            {
                var collection = section.Reporting.Factories;
                foreach (var processorData in collection.OrderBy(p => p.Priority))
                {
                    RegisterFactory(processorData.FactoryType);
                }
            }
        }

        //- $InitReporterData -//
        private static void InitReporterData()
        {
            var section = SystemSection.GetConfigSection();
            if (section != null)
            {
                var reportingElement = section.Reporting;
                if (reportingElement != null)
                {
                    var collection = reportingElement.Reporters;
                    foreach (var reporterData in collection)
                    {
                        if (reporterData.Enabled)
                        {
                            Create(reporterData.Name, reporterData.Creator, reporterData.Sender, reporterData.Formatter);
                        }
                    }
                }
            }
        }

        //- $CreateReportCreator -//
        private static ReportCreator.ReportCreator CreateReportCreator(string reportCreatorType)
        {
            readerWriterLockSlim.EnterUpgradeableReadLock();
            try
            {
                ReportCreator.ReportCreator creator = null;
                if (!ReportCreatorCache.ContainsKey(reportCreatorType))
                {
                    readerWriterLockSlim.EnterWriteLock();
                    //+
                    try
                    {
                        if (!ReportCreatorCache.ContainsKey(reportCreatorType))
                        {
                            creator = ReportCreatorActivator.Create(reportCreatorType, ReportCreatorFactoryCache);
                            ReportCreatorCache.Add(reportCreatorType, creator);
                        }
                    }
                    finally
                    {
                        readerWriterLockSlim.ExitWriteLock();
                    }
                }
                if (creator == null)
                {
                    creator = ReportCreatorCache.Get<ReportCreator.ReportCreator>(reportCreatorType);
                }
                //+
                return creator;
            }
            finally
            {
                readerWriterLockSlim.ExitUpgradeableReadLock();
            }
        }

        //- $CreateSender -//
        private static Sender.Sender CreateSender(string reportCreatorType)
        {
            readerWriterLockSlim.EnterUpgradeableReadLock();
            try
            {
                Sender.Sender sender = null;
                if (!SenderCache.ContainsKey(reportCreatorType))
                {
                    readerWriterLockSlim.EnterWriteLock();
                    //+
                    try
                    {
                        if (!SenderCache.ContainsKey(reportCreatorType))
                        {
                            sender = SenderActivator.Create(reportCreatorType, SenderFactoryCache);
                            SenderCache.Add(reportCreatorType, sender);
                        }
                    }
                    finally
                    {
                        readerWriterLockSlim.ExitWriteLock();
                    }
                }
                if (sender == null)
                {
                    sender = SenderCache.Get<Sender.Sender>(reportCreatorType);
                }
                //+
                return sender;
            }
            finally
            {
                readerWriterLockSlim.ExitUpgradeableReadLock();
            }
        }

        //- $CreateFormatter -//
        private static Formatter CreateFormatter(string reportCreatorType)
        {
            readerWriterLockSlim.EnterUpgradeableReadLock();
            try
            {
                Formatter formatter = null;
                if (!FormatterCache.ContainsKey(reportCreatorType))
                {
                    readerWriterLockSlim.EnterWriteLock();
                    //+
                    try
                    {
                        if (!FormatterCache.ContainsKey(reportCreatorType))
                        {
                            formatter = FormatterActivator.Create(reportCreatorType, FormatterFactoryCache);
                            FormatterCache.Add(reportCreatorType, formatter);
                        }
                    }
                    finally
                    {
                        readerWriterLockSlim.ExitWriteLock();
                    }
                }
                if (formatter == null)
                {
                    formatter = FormatterCache.Get<Formatter>(reportCreatorType);
                }
                //+
                return formatter;
            }
            finally
            {
                readerWriterLockSlim.ExitUpgradeableReadLock();
            }
        }
    }
}