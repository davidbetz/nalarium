#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
using System.Configuration;
//+
namespace Nalarium.Configuration
{
    public class FactoryCollection : Nalarium.Configuration.CommentableCollection<FactoryElement>
    {
        //- #GetElementKey -//
        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((FactoryElement)element).FactoryType;
        }
    }
}