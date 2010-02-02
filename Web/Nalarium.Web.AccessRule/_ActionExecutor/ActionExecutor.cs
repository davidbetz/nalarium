#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
namespace Nalarium.Web.AccessRule
{
    public abstract class ActionExecutor
    {
        //- @Name -//
        public String Name { get; set; }

        //- @Value -//
        public String Value { get; set; }

        //+
        //- @Execute -//
        public abstract void Execute();
    }
}