#region Copyright

//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010

#endregion

#region Reference

//+ http://www.netfxharmonics.com/2006/01/Constrainted-try-with-retry-mechanism

#endregion

using System;
using System.Threading;

namespace Nalarium.ExceptionHandling
{
    //+
    /// <summary>
    /// Enabled the use of exception retries.
    /// </summary>
    public static class ExceptionRetry
    {
        //- @TryWithRetryConstraints -//
        /// <summary>
        /// Tries the exception with retry constraints.
        /// </summary>
        /// <param name="retryCount">The retry count.</param>
        /// <param name="sleepTime">The sleep time.</param>
        /// <param name="constraints">The constraints.</param>
        /// <param name="tryBlock">The try block.</param>
        /// <param name="catchBlock">The catch block.</param>
        public static void TryWithRetryConstraints(
            Int32 retryCount,
            Int32 sleepTime,
            ExceptionConstraintCollection constraints,
            ExceptionTryBlock tryBlock,
            ExceptionCatchBlock catchBlock)
        {
            Int32 n = 0;
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
                        foreach (Object constraint in constraints)
                        {
                            if (constraint is Type)
                            {
                                Boolean isException = false;
                                if (((Type)constraint).Name == "Exception")
                                {
                                    isException = true;
                                }
                                Type parent = ((Type)constraint).BaseType;
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
                                    Exception thrownException = ex;
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
                            else if (constraint is String)
                            {
                                if (ex.Message.Contains((String)constraint))
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
                        break;
                    }
                }
                break;
            }
        }
    }
}