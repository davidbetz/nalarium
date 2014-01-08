#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;

namespace Nalarium.Reporting.Sender
{
    public abstract class Sender
    {
        //- @ContentType -//
        /// <summary>
        /// Gets or sets the type of the content.
        /// </summary>
        /// <value>The type of the content.</value>
        public String ContentType { get; set; }

        //- @AllowExceptionThrowing -//
        /// <summary>
        /// Represents a setting which states whether the sender is allowed to throw exceptions.
        /// </summary>
        /// <value>If false (the default), thrown exceptions are eaten by the sender.</value>
        public Boolean AllowExceptionThrowing { get; set; }

        //- @Send -//
        /// <summary>
        /// Sends the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="extra">The extra.</param>
        /// <param name="isException">if set to <c>true</c> [is exception].</param>
        public void Send(String data, String extra, Boolean isException)
        {
            try
            {
                if (!String.IsNullOrEmpty(data))
                {
                    SendCore(data, extra, isException);
                }
            }
            catch
            {
                if (AllowExceptionThrowing)
                {
                    throw;
                }
            }
        }

        //- @SendCore -//
        /// <summary>
        /// Represents the implementation for data sending.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="extra">The extra.</param>
        /// <param name="isException">if set to <c>true</c> [is exception].</param>
        protected abstract void SendCore(String data, String extra, Boolean isException);
    }
}