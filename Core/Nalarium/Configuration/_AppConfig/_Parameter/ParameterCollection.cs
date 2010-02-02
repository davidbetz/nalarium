#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
using System.Configuration;
using System.Linq;
//+
namespace Nalarium.Configuration
{
    public class ParameterCollection : CommentableCollection<ParameterElement>
    {
        //- #GetElementKey -//
        protected override Object GetElementKey(ConfigurationElement element)
        {
            return GuidCreator.GetNewGuid();
        }

        //- @GetValue -//
        public String GetValue(String name)
        {
            ParameterElement element = this.SingleOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (element != null)
            {
                return element.Value;
            }
            //+
            return String.Empty;
        }
    }
}