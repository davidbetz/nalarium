#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using System.Configuration;
using System.Linq;

namespace Nalarium.Configuration.AppConfig.Parameter
{
    public class ParameterCollection : CommentableCollection<ParameterElement>
    {
        //- #GetElementKey -//
        protected override System.Object GetElementKey(ConfigurationElement element)
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