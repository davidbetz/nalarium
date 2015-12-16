#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System.Configuration;

namespace Nalarium.Configuration.AppConfig.Object
{
    public class ObjectCollection : CommentableCollection<ObjectElement>
    {
        //- #GetElementKey -//
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ObjectElement) element).Name;
        }
    }
}