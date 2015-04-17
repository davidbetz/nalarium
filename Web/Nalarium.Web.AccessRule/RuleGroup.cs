#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Collections.Generic;

namespace Nalarium.Web.AccessRule
{
    internal class RuleGroup : List<Rule>
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