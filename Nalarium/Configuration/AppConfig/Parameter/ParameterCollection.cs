#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System;
using System.Configuration;
using System.Linq;

namespace Nalarium.Configuration.AppConfig.Parameter
{
    public class ParameterCollection : CommentableCollection<ParameterElement>
    {
        //- #GetElementKey -//
        protected override object GetElementKey(ConfigurationElement element)
        {
            return GuidCreator.GetNewGuid();
        }

        //- @GetValue -//
        public string GetValue(string name)
        {
            var element = this.SingleOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (element != null)
            {
                return element.Value;
            }
            //+
            return string.Empty;
        }
    }
}