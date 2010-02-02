#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
//+
namespace Nalarium.Reporting
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
            Exception exceptionData = content as Exception;
            if (exceptionData != null)
            {
                Write(exceptionData.Message, exceptionData);
            }
            else
            {
                Object[] data = content as Object[];
                if (data != null)
                {
                    this.Write("Information Report", FormatterType.MainHeading);
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
            return this.Result.ToString();
        }

        //- $Write -//
        private void Write(String message, Exception exception)
        {
            this.Write("Message", FormatterType.Heading);
            this.Write(message, FormatterType.Normal);
            this.Write(FormatterType.Break);
            //+
            String fullname = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            this.Write("User", FormatterType.SubHeading);
            this.Write(fullname, FormatterType.Normal);
            this.Write(FormatterType.Break);
            this.Write("Time", FormatterType.SubHeading);
            this.Write(DateTime.Now.ToString(), FormatterType.Normal);
            this.Write(FormatterType.Break);
            this.Write("Details", FormatterType.Heading);
            this.Write("exception.Message", FormatterType.SubHeading);
            this.Write(exception.Message, FormatterType.Normal);
            this.Write("exception.StackTrace", FormatterType.SubHeading);
            this.Write(exception.StackTrace, FormatterType.Normal);
            this.Write(FormatterType.Break);
            Exception innerException = exception.InnerException;
            while (innerException != null)
            {
                this.Write("innerException.Message", FormatterType.SubHeading);
                this.Write(innerException.Message, FormatterType.Normal);
                this.Write("innerException.StackTrace", FormatterType.SubHeading);
                this.Write(innerException.StackTrace, FormatterType.Normal);
                this.Write(FormatterType.Break);
                innerException = innerException.InnerException;
            }
        }
    }
}