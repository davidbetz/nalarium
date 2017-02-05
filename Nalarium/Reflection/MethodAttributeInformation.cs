#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System;
using System.Reflection;

namespace Nalarium.Reflection
{
    public class MethodAttributeInformation<TAttribute>
        where TAttribute : Attribute
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