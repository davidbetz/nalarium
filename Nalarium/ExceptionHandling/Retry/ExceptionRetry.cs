#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

#region Reference

//+ http://www.netfxharmonics.com/2006/01/Constrainted-try-with-retry-mechanism

#endregion

using System;
using System.Threading;

namespace Nalarium.ExceptionHandling.Retry
{
    //+
    /// <summary>
    ///     Enabled the use of exception retries.
    /// </summary>
    public static class ExceptionRetry
    {
        //- @TryWithRetryConstraints -//
        /// <summary>
        ///     Tries the exception with retry constraints.
        /// </summary>
        /// <param name="retryCount">The retry count.</param>
        /// <param name="sleepTime">The sleep time.</param>
        /// <param name="constraints">The constraints.</param>
        /// <param name="tryBlock">The try block.</param>
        /// <param name="catchBlock">The catch block.</param>
        public static void TryWithRetryConstraints(
            int retryCount,
            int sleepTime,
            ExceptionConstraintCollection constraints,
            ExceptionTryBlock tryBlock,
            ExceptionCatchBlock catchBlock)
        {
            var n = 0;
            while (true)
            {
                try
                {
                    tryBlock.DynamicInvoke();
                }
                catch (Exception ex)
                {
                    if (++n < retryCount)
                    {
                        foreach (var constraint in constraints)
                        {
                            if (constraint is Type)
                            {
                                var isException = false;
                                if (((Type) constraint).Name == "Exception")
                                {
                                    isException = true;
                                }
                                var parent = ((Type) constraint).BaseType;
                                while (!isException && parent.Name != "Object")
                                {
                                    if (parent.Name == "Exception")
                                    {
                                        isException = true;
                                    }
                                    parent = parent.BaseType;
                                }
                                if (isException)
                                {
                                    var thrownException = ex;
                                    while (thrownException != null)
                                    {
                                        if (thrownException.GetType().ToString() == constraint.ToString())
                                        {
                                            Thread.Sleep(sleepTime);
                                            //+
                                            continue;
                                        }

                                        thrownException = thrownException.InnerException;
                                    }
                                }
                            }
                            else if (constraint is string)
                            {
                                if (ex.Message.Contains((string) constraint))
                                {
                                    Thread.Sleep(sleepTime);
                                    //+
                                    continue;
                                }
                            }
                            catchBlock.DynamicInvoke(ex);
                            //+
                            return;
                        }
                    }
                    else
                    {
                        catchBlock.DynamicInvoke(ex);
                    }
                }
                break;
            }
        }
    }
}