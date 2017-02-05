#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System;
using System.Reflection;

namespace Nalarium.Reflection
{
    public class PropertyAttributeInformation<TAttribute>
        where TAttribute : Attribute
    {
        //- @PropertyInfo -//
        public PropertyInfo PropertyInfo { get; set; }

        //- @Attribute -//
        public TAttribute Attribute { get; set; }
    }

    public class PropertyAttributeInformation
    {
        //- @PropertyInfo -//
        public PropertyInfo PropertyInfo { get; set; }

        //- @Attribute -//
        public Attribute Attribute { get; set; }
    }
}