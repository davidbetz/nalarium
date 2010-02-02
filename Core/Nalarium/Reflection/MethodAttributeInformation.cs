#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright � Jampad Technology, Inc. 2007-2010
#endregion
using System;
using System.Reflection;
//+
namespace Nalarium.Reflection
{
    public class MethodAttributeInformation<TAttribute> where TAttribute : System.Attribute
    {
        //- @MethodInfo -//
        public MethodInfo MethodInfo { get; set; }

        //- @Attribute -//
        public TAttribute Attribute { get; set; }
    }
    public class MethodAttributeInformation
    {
        //- @MethodInfo -//
        public MethodInfo MethodInfo { get; set; }

        //- @Attribute -//
        public Attribute Attribute { get; set; }
    }
}