#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using System.Security.Principal;
using Nalarium.Reporting.ReportCreator.Formatter;

namespace Nalarium.Reporting.ReportCreator
{
    public class ExceptionReportCreator : ReportCreator
    {
        //- @IsException -//
        public override Boolean IsException
        {
            get
            {
                return true;
            }
        }

        //+
        //- @CreateCore -//
        /// <summary>
        /// Generates the report.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <returns></returns>
        protected override String CreateCore(Object content)
        {
            var exceptionData = content as Exception;
            if (exceptionData != null)
            {
                Write(exceptionData.Message, exceptionData);
            }
            else
            {
                var data = content as Object[];
                if (data != null)
                {
                    Write("Information Report", FormatterType.MainHeading);
                    //+
                    String message;
                    Exception exception;
                    if (IsValid(data, out message, out exception))
                    {
                        Write(message, exception);
                    }
                }
            }
            //+
            return Result.ToString();
        }

        //- $Write -//
        private void Write(String message, Exception exception)
        {
            Write("Message", FormatterType.Heading);
            Write(message, FormatterType.Normal);
            Write(FormatterType.Break);
            //+
            String fullname = WindowsIdentity.GetCurrent().Name;
            Write("User", FormatterType.SubHeading);
            Write(fullname, FormatterType.Normal);
            Write(FormatterType.Break);
            Write("Time", FormatterType.SubHeading);
            Write(DateTime.Now.ToString(), FormatterType.Normal);
            Write(FormatterType.Break);
            Write("Details", FormatterType.Heading);
            Write("exception.Message", FormatterType.SubHeading);
            Write(exception.Message, FormatterType.Normal);
            Write("exception.StackTrace", FormatterType.SubHeading);
            Write(exception.StackTrace, FormatterType.Normal);
            Write(FormatterType.Break);
            Exception innerException = exception.InnerException;
            while (innerException != null)
            {
                Write("innerException.Message", FormatterType.SubHeading);
                Write(innerException.Message, FormatterType.Normal);
                Write("innerException.StackTrace", FormatterType.SubHeading);
                Write(innerException.StackTrace, FormatterType.Normal);
                Write(FormatterType.Break);
                innerException = innerException.InnerException;
            }
        }
    }
}