#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
//+
using System;
//+
namespace Nalarium.Web.AccessRule.Configuration
{
    public class WhenCollection : Nalarium.Configuration.CommentableCollection<MatchElement>
    {
        //- #GetElementKey -//
        protected override Object GetElementKey(System.Configuration.ConfigurationElement element)
        {
            return GuidCreator.GetNewGuid();
        }
    }
}