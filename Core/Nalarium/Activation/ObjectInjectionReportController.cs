#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System.Threading;
//+
using Nalarium.Reporting;
//+
namespace Nalarium.Activation
{
    internal static class ObjectInjectionReportController
    {
        internal static Reporter reporter;
        private static ReaderWriterLockSlim readerWriterLockSlim = new ReaderWriterLockSlim();

        //+
        public const string CoreInjectionDebugReporter = "CoreInjectionDebug";

        //- $Reporter -//
        internal static Reporter Reporter
        {
            get
            {
                try
                {
                    readerWriterLockSlim.EnterUpgradeableReadLock();
                    if (reporter == null)
                    {
                        readerWriterLockSlim.EnterWriteLock();
                        try
                        {
                            if (reporter == null)
                            {
                                reporter = (Reporter)ReportController.GetReporter(ObjectInjectionReportController.CoreInjectionDebugReporter);
                            }
                        }
                        finally
                        {
                            readerWriterLockSlim.ExitWriteLock();
                        }
                    }
                    //+
                    return reporter;
                }
                finally
                {
                    readerWriterLockSlim.ExitUpgradeableReadLock();
                }
            }
        }
    }
}