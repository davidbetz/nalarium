#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System.Configuration;

namespace Nalarium.Configuration.AppConfig.Factory
{
    public class FactoryCollection : CommentableCollection<FactoryElement>
    {
        //- #GetElementKey -//
        protected override System.Object GetElementKey(ConfigurationElement element)
        {
            return ((FactoryElement)element).FactoryType;
        }
    }
}