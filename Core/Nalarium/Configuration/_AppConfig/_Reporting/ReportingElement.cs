#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System.Configuration;

namespace Nalarium.Configuration
{
    public class ReportingElement : CommentableElement
    {
        //- @Factories -//
        [ConfigurationProperty("factories")]
        [ConfigurationCollection(typeof(TypeParameterElement), AddItemName = "add")]
        public FactoryCollection Factories
        {
            get
            {
                return (FactoryCollection)this["factories"];
            }
        }

        //- @Reporters -//
        [ConfigurationProperty("reporters")]
        [ConfigurationCollection(typeof(ReporterElement), AddItemName = "add")]
        public ReporterCollection Reporters
        {
            get
            {
                return (ReporterCollection)this["reporters"];
            }
        }

        //- @ReporterFactories -//
        [ConfigurationProperty("reporterFactories")]
        [ConfigurationCollection(typeof(ParameterCollection), AddItemName = "add")]
        public ReporterFactoryCollection ReporterFactories
        {
            get
            {
                return (ReporterFactoryCollection)this["reporterFactories"];
            }
        }

        //- @SenderFactories -//
        [ConfigurationProperty("senderFactories")]
        [ConfigurationCollection(typeof(ParameterCollection), AddItemName = "add")]
        public SenderFactoryCollection SenderFactories
        {
            get
            {
                return (SenderFactoryCollection)this["senderFactories"];
            }
        }

        //- @FormatterFactories -//
        [ConfigurationProperty("formatterFactories")]
        [ConfigurationCollection(typeof(ParameterCollection), AddItemName = "add")]
        public FormatterFactoryCollection FormatterFactories
        {
            get
            {
                return (FormatterFactoryCollection)this["formatterFactories"];
            }
        }
    }
}