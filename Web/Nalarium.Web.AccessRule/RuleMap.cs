#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
namespace Nalarium.Web.AccessRule
{
    internal class RuleMap : Map<String, RuleGroup>
    {
        internal static Object _Lock = new Object();

        //+
        //- @Current -//
        public static RuleMap Current { get; set; }
    }
}