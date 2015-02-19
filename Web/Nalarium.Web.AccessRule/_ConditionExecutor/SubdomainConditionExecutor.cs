#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;

namespace Nalarium.Web.AccessRule
{
    public class SubdomainConditionExecutor : ConditionExecutor
    {
        //- @Process -//
        public override Boolean Process()
        {
            return Http.SubDomainPartArray[0].Equals(Value);
        }
    }
}