#region Copyright

//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010

#endregion

using System;
using System.Configuration;

namespace Nalarium.Configuration
{
    public class ObjectCollection : CommentableCollection<ObjectElement>
    {
        //- #GetElementKey -//
        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((ObjectElement)element).Name;
        }
    }
}