#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System.Threading;
using Nalarium.Reporting;
//+

namespace Nalarium.Activation
{
    internal static class ObjectInjectionReportController
    {
        public const string CoreInjectionDebugReporter = "CoreInjectionDebug";
        internal static Reporter reporter;
        private static readonly ReaderWriterLockSlim readerWriterLockSlim = new ReaderWriterLockSlim();

        //+

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
                                reporter = ReportController.GetReporter(CoreInjectionDebugReporter);
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