#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System.Configuration;
using Nalarium.Configuration.AppConfig.Factory;
using Nalarium.Configuration.AppConfig.Parameter;
using Nalarium.Configuration.AppConfig.Type;

namespace Nalarium.Configuration.AppConfig.Reporting
{
    public class ReportingElement : CommentableElement
    {
        //- @Factories -//
        [ConfigurationProperty("factories")]
        [ConfigurationCollection(typeof (TypeParameterElement), AddItemName = "add")]
        public FactoryCollection Factories
        {
            get { return (FactoryCollection) this["factories"]; }
        }

        //- @Reporters -//
        [ConfigurationProperty("reporters")]
        [ConfigurationCollection(typeof (ReporterElement), AddItemName = "add")]
        public ReporterCollection Reporters
        {
            get { return (ReporterCollection) this["reporters"]; }
        }

        //- @ReporterFactories -//
        [ConfigurationProperty("reporterFactories")]
        [ConfigurationCollection(typeof (ParameterCollection), AddItemName = "add")]
        public ReporterFactoryCollection ReporterFactories
        {
            get { return (ReporterFactoryCollection) this["reporterFactories"]; }
        }

        //- @SenderFactories -//
        [ConfigurationProperty("senderFactories")]
        [ConfigurationCollection(typeof (ParameterCollection), AddItemName = "add")]
        public SenderFactoryCollection SenderFactories
        {
            get { return (SenderFactoryCollection) this["senderFactories"]; }
        }

        //- @FormatterFactories -//
        [ConfigurationProperty("formatterFactories")]
        [ConfigurationCollection(typeof (ParameterCollection), AddItemName = "add")]
        public FormatterFactoryCollection FormatterFactories
        {
            get { return (FormatterFactoryCollection) this["formatterFactories"]; }
        }
    }
}