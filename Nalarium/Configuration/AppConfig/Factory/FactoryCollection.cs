#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System.Configuration;

namespace Nalarium.Configuration.AppConfig.Factory
{
    public class FactoryCollection : CommentableCollection<FactoryElement>
    {
        //- #GetElementKey -//
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((FactoryElement) element).FactoryType;
        }
    }
}