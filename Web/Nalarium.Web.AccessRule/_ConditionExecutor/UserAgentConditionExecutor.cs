#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;

namespace Nalarium.Web.AccessRule
{
    public class UserAgentConditionExecutor : ConditionExecutor
    {
        //- @Process -//
        public override Boolean Process()
        {
            if (String.IsNullOrEmpty(Value) || String.IsNullOrEmpty(Http.UserAgent))
            {
                return false;
            }
            //+
            return Http.UserAgent.ToLower().Contains(Value.ToLower());
        }
    }
}