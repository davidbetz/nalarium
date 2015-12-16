#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System.Configuration;

namespace Nalarium.Configuration.AppConfig.Type
{
    public class TypeParameterCollection : CommentableCollection<TypeParameterElement>
    {
        //- #GetElementKey -//
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TypeParameterElement) element).Type;
        }
    }
}