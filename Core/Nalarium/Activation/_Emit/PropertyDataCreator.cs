#region Copyright

//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010

#endregion

using System;

namespace Nalarium.Activation
{
    public static class PropertyDataCreator
    {
        //- @Create -//
        /// <summary>
        /// Creates a generic PropertyData&lt;T&gt; object.
        /// </summary>
        /// <param name="name">Property name.</param>
        /// <param name="type">Property value.</param>
        /// <returns>Instance of desired generic PropertyData type.</returns>
        public static PropertyDataBase Create(String name, Type type)
        {
            Type closedType = typeof(PropertyData<>).MakeGenericType(type);
            var propertyData = Activator.CreateInstance(closedType) as PropertyDataBase;
            propertyData.Name = name;
            //+
            return propertyData;
        }
    }
}