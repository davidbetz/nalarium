#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
namespace Nalarium.Web.AccessRule
{
    internal class RuleGroup : System.Collections.Generic.List<Rule>
    {
        public Boolean HasPermit
        {
            get
            {
                if (this[Count - 1].GetType() == typeof(PermitExecutor))
                {
                    return true;
                }
                //+
                return false;
            }
        }
    }
}