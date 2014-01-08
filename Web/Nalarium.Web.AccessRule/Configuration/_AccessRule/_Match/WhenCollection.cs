#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

//+
using System;
using System.Configuration;
using Nalarium.Configuration;
using Nalarium.Configuration.AppConfig;

namespace Nalarium.Web.AccessRule.Configuration
{
    public class WhenCollection : CommentableCollection<MatchElement>
    {
        //- #GetElementKey -//
        protected override Object GetElementKey(ConfigurationElement element)
        {
            return GuidCreator.GetNewGuid();
        }
    }
}