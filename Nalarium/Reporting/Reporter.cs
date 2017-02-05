#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System;
using Nalarium.Globalization;
using Nalarium.Properties;
using Nalarium.Reporting.ReportCreator.Formatter;

namespace Nalarium.Reporting
{
    public class Reporter
    {
        private string contentType = string.Empty;

        //+
        //- @ReportCreator -//
        /// <summary>
        ///     Gets or sets the report creator.
        /// </summary>
        /// <value>The report creator.</value>
        public ReportCreator.ReportCreator ReportCreator { get; set; }

        //- @ReportSender -//
        /// <summary>
        ///     Gets or sets the report sender.
        /// </summary>
        /// <value>The report sender.</value>
        public Sender.Sender ReportSender { get; set; }

        //- @Formatter -//
        /// <summary>
        ///     Gets or sets the formatter.
        /// </summary>
        /// <value>The formatter.</value>
        public Formatter Formatter { get; set; }

        //- @Name -//
        /// <summary>
        ///     Gets or sets the reporter name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        //- @Initialized -//
        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="Reporter" /> is initialized.
        /// </summary>
        /// <value><c>true</c> if initialized; otherwise, <c>false</c>.</value>
        public bool Initialized { get; internal set; }

        //- @ContentType -//
        /// <summary>
        ///     Gets or sets the content type
        /// </summary>
        /// <value>The type of the content.</value>
        public string ContentType
        {
            get
            {
                if (!string.IsNullOrEmpty(contentType) && contentType.Contains("/"))
                {
                    return contentType;
                }
                if (Formatter != null)
                {
                    return Formatter.PreferredContentType;
                }
                //+
                return "text/plain";
            }
            set { contentType = value; }
        }

        //- @HasDataToSend -//
        /// <summary>
        ///     Represents the state of the data to send.  True is there is data to send, otherwise false.
        /// </summary>
        public bool HasDataToSend
        {
            get { return ReportCreator != null && ReportCreator.Data.Count > 0; }
        }

        //+
        //- @Create -//
        /// <summary>
        ///     Creates the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="creator">The creator.</param>
        /// <param name="sender">The sender.</param>
        /// <param name="formatter">The formatter.</param>
        /// <returns></returns>
        internal static Reporter Create(string name, ReportCreator.ReportCreator creator, Sender.Sender sender, Formatter formatter)
        {
            return new Reporter
            {
                Name = name,
                ReportCreator = creator,
                ReportSender = sender,
                Formatter = formatter
            };
        }

        //- @AddMap -//
        /// <summary>
        ///     Adds the specified map.
        /// </summary>
        /// <param name="map">The map.</param>
        public void AddMap(object data)
        {
            if (ReportCreator == null)
            {
                throw new ArgumentNullException(ResourceAccessor.GetString("Report_CreatorRequired", AssemblyInfo.AssemblyName, Resource.ResourceManager));
            }
            ReportCreator.AddMap(data);
        }

        //- @InsertMap -//
        /// <summary>
        ///     Inserts a map at a particular location.
        /// </summary>
        /// <param name="map">The map to insert into the data list.</param>
        /// <param name="index">The index at which to insert the map.</param>
        public void InsertMap(Map map, int index)
        {
            ReportCreator.InsertMap(map, index);
        }

        //- @Initialize -//
        /// <summary>
        ///     Attempts to initialize the reporter.  The status of the Initialized property will change to true if successful.
        ///     Initialization is successful when a repoter has a creator, a formatter, and a sender.
        /// </summary>
        public void Initialize()
        {
            if (ReportCreator != null && ReportSender != null && Formatter != null)
            {
                Initialized = true;
            }
        }

        //- @Send -//
        /// <summary>
        ///     Sends the report.
        /// </summary>
        public void Send()
        {
            Send(string.Empty, false);
        }

        /// <summary>
        ///     Sends the report.
        /// </summary>
        /// <param name="isException">if set to <c>true</c>, an exception is being sent</param>
        public void Send(bool isException)
        {
            Send(string.Empty, isException);
        }

        /// <summary>
        ///     Sends the report.
        /// </summary>
        /// <param name="extra">The extra.</param>
        /// <param name="isException">if set to <c>true</c>, an exception is being sent</param>
        public void Send(string extra, bool isException)
        {
            if (!Initialized)
            {
                throw new ArgumentNullException(ResourceAccessor.GetString("Report_NotInitialized", AssemblyInfo.AssemblyName, Resource.ResourceManager));
            }
            if (ReportCreator == null)
            {
                throw new ArgumentNullException(string.Format(ResourceAccessor.GetString(string.Format("Report_NotValid", "creator"), AssemblyInfo.AssemblyName, Resource.ResourceManager), "ReportCreator"));
            }
            if (ReportSender == null)
            {
                throw new ArgumentNullException(string.Format(ResourceAccessor.GetString(string.Format("Report_NotValid", "sender"), AssemblyInfo.AssemblyName, Resource.ResourceManager), "ReportSender"));
            }
            if (Formatter == null)
            {
                throw new ArgumentNullException(string.Format(ResourceAccessor.GetString(string.Format("Report_NotValid", "formatter"), AssemblyInfo.AssemblyName, Resource.ResourceManager), "Formatter"));
            }
            if (ReportCreator.IsException)
            {
                isException = true;
            }
            //+
            ReportSender.ContentType = ContentType;
            ReportCreator.Formatter = Formatter;
            ReportSender.Send(ReportCreator.Create(), extra, isException);
        }

        //- @SendSingle -//
        /// <summary>
        ///     Sends a single report item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void SendSingle(object data)
        {
            SendSingle(data, string.Empty, false);
        }

        /// <summary>
        ///     Sends a single report item.
        /// </summary>
        /// <param name="data">The item.</param>
        /// <param name="extra">The extra.</param>
        /// <param name="isException">if set to <c>true</c> [is exception].</param>
        public void SendSingle(object data, string extra, bool isException)
        {
            if (ReportCreator == null)
            {
                throw new ArgumentNullException(string.Format(ResourceAccessor.GetString(string.Format("Report_NotValid", "creator"), AssemblyInfo.AssemblyName, Resource.ResourceManager), "ReportCreator"));
            }
            if (ReportSender == null)
            {
                throw new ArgumentNullException(string.Format(ResourceAccessor.GetString(string.Format("Report_NotValid", "sender"), AssemblyInfo.AssemblyName, Resource.ResourceManager), "ReportSender"));
            }
            if (Formatter == null)
            {
                throw new ArgumentNullException(string.Format(ResourceAccessor.GetString(string.Format("Report_NotValid", "formatter"), AssemblyInfo.AssemblyName, Resource.ResourceManager), "Formatter"));
            }
            if (ReportCreator.IsException || data is Exception)
            {
                isException = true;
            }
            //+
            ReportSender.ContentType = ContentType;
            ReportCreator.Formatter = Formatter;
            ReportSender.Send(ReportCreator.Create(data), extra, isException);
        }
    }
}