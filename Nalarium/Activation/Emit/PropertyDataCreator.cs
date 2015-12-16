#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System;

namespace Nalarium.Activation.Emit
{
    public static class PropertyDataCreator
    {
        //- @Create -//
        /// <summary>
        ///     Creates a generic PropertyData&lt;T&gt; object.
        /// </summary>
        /// <param name="name">Property name.</param>
        /// <param name="type">Property value.</param>
        /// <returns>Instance of desired generic PropertyData type.</returns>
        public static PropertyDataBase Create(string name, Type type)
        {
            var closedType = typeof(PropertyData<>).MakeGenericType(type);
            var propertyData = Activator.CreateInstance(closedType) as PropertyDataBase;
            if (propertyData == null)
            {
                return null;
            }
            propertyData.Name = name;
            //+
            return propertyData;
        }
    }
}