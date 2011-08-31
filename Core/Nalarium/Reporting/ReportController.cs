#region Copyright

//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010

#endregion

using System;
using System.Linq;
using System.Threading;
using Nalarium.Activation;
using Nalarium.Configuration;
//+

namespace Nalarium.Reporting
{
    public static class ReportController
    {
        private static readonly ReaderWriterLockSlim readerWriterLockSlim = new ReaderWriterLockSlim();
        private static readonly Object _lock = new Object();

        //+
        internal static Map<String, ReportCreator> ReportCreatorCache = new Map<String, ReportCreator>();
        internal static Map<String, Sender> SenderCache = new Map<String, Sender>();
        internal static Map<String, Formatter> FormatterCache = new Map<String, Formatter>();
        //+
        internal static Map<String, ReportCreatorFactory> ReportCreatorFactoryCache = new Map<String, ReportCreatorFactory>();
        internal static Map<String, SenderFactory> SenderFactoryCache = new Map<String, SenderFactory>();
        internal static Map<String, FormatterFactory> FormatterFactoryCache = new Map<String, FormatterFactory>();

        //+
        //- $ReporterMap -//
        private static readonly Map<String, Reporter> ReporterMap = new Map<String, Reporter>();

        //+
        //- @Ctor -//
        static ReportController()
        {
            ReportCreatorFactoryCache.Add("Nalarium.Reporting.CommonReportCreatorFactory, Nalarium", new CommonReportCreatorFactory());
            SenderFactoryCache.Add("Nalarium.Reporting.CommonSenderFactory, Nalarium", new CommonSenderFactory());
            FormatterFactoryCache.Add("Nalarium.Reporting.CommonFormatterFactory, Nalarium", new CommonFormatterFactory());
            //+
            InitFactoryData();
            InitReporterData();
        }

        //+
        //- @GetReporter -//
        /// <summary>
        /// Gets the reporter.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static Reporter GetReporter(String name)
        {
            lock (_lock)
            {
                if (ReporterMap.ContainsKey(name))
                {
                    Reporter reporter = ReporterMap[name];
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
        /// Registers the factory.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="factory">The factory.</param>
        public static void RegisterFactory(String factoryType)
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
                                    SenderFactoryCache.Add(factoryType, (SenderFactory)factory);
                                }
                                else if (factory is FormatterFactory)
                                {
                                    FormatterFactoryCache.Add(factoryType, (FormatterFactory)factory);
                                }
                                else if (factory is ReportCreatorFactory)
                                {
                                    ReportCreatorFactoryCache.Add(factoryType, (ReportCreatorFactory)factory);
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
        /// Creates the specified report creator type.
        /// </summary>
        /// <param name="reportCreatorType">Type of the report creator.</param>
        /// <param name="senderType">Type of the sender.</param>
        /// <param name="formatterType">Type of the formatter.</param>
        /// <returns></returns>
        public static Reporter Create(String reportCreatorType, String senderType, String formatterType)
        {
            return Create(String.Empty, reportCreatorType, senderType, formatterType);
        }

        /// <summary>
        /// Creates the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="reportCreatorType">Type of the report creator.</param>
        /// <param name="senderType">Type of the sender.</param>
        /// <param name="formatterType">Type of the formatter.</param>
        /// <returns></returns>
        public static Reporter Create(String name, String reportCreatorType, String senderType, String formatterType)
        {
            ReportCreator creator = CreateReportCreator(reportCreatorType);
            Sender sender = CreateSender(senderType);
            Formatter formatter = CreateFormatter(formatterType);
            //+
            lock (_lock)
            {
                Reporter reporter = Reporter.Create(name, creator, sender, formatter);
                if (!String.IsNullOrEmpty(name))
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
            SystemSection section = SystemSection.GetConfigSection();
            if (section != null)
            {
                FactoryCollection collection = section.Reporting.Factories;
                foreach (FactoryElement processorData in collection.OrderBy(p => p.Priority))
                {
                    RegisterFactory(processorData.FactoryType);
                }
            }
        }

        //- $InitReporterData -//
        private static void InitReporterData()
        {
            SystemSection section = SystemSection.GetConfigSection();
            if (section != null)
            {
                ReportingElement reportingElement = section.Reporting;
                if (reportingElement != null)
                {
                    ReporterCollection collection = reportingElement.Reporters;
                    foreach (ReporterElement reporterData in collection)
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
        private static ReportCreator CreateReportCreator(String reportCreatorType)
        {
            readerWriterLockSlim.EnterUpgradeableReadLock();
            try
            {
                ReportCreator creator = null;
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
                    creator = ReportCreatorCache.PeekSafely<ReportCreator>(reportCreatorType);
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
        private static Sender CreateSender(String reportCreatorType)
        {
            readerWriterLockSlim.EnterUpgradeableReadLock();
            try
            {
                Sender sender = null;
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
                    sender = SenderCache.PeekSafely<Sender>(reportCreatorType);
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
        private static Formatter CreateFormatter(String reportCreatorType)
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
                    formatter = FormatterCache.PeekSafely<Formatter>(reportCreatorType);
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