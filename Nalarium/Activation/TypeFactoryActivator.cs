#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using System.Collections.Generic;
using System.Globalization;

//+
//+

namespace Nalarium.Activation
{
    public static class TypeFactoryActivator
    {
        //- @Create -//
        /// <summary>
        /// Used to create a type factory from the type factory cache.
        /// </summary>
        /// <typeparam name="T">The type of the type factory.</typeparam>
        /// <param name="objectType">The name of the type to be created</param>
        /// <returns>A created type factory of type T; null if the appropriate type factory was not found</returns>
        public static Type Create(String objectType)
        {
            return Create(objectType, FactoryCache.TypeFactoryCache);
        }

        /// <summary>
        /// Used to create a type factory from a specified factory map.
        /// </summary>
        /// <typeparam name="T">The type of the type factory.</typeparam>
        /// <param name="objectType">The name of the type to be created</param>
        /// <param name="objectFactoryMap">The specified factory map</param>
        /// <returns>A created type factory of type T; null if the appropriate type factory was not found</returns>
        public static Type Create(String objectType, Map<String, IFactory> objectFactoryMap)
        {
            Type processor = null;
            if (objectType.Contains(","))
            {
                return ObjectCreator.CreateAs<Type>(objectType);
            }
            //+
            if (processor == null && objectFactoryMap != null)
            {
                List<IFactory> processorFactoryList = objectFactoryMap.GetValueList();
                foreach (IFactory factory in processorFactoryList)
                {
                    objectType = objectType.ToLower(CultureInfo.CurrentCulture);
                    processor = ((TypeFactory)factory).CreateType(objectType);
                    if (processor != null)
                    {
                        break;
                    }
                }
            }
            //+
            return processor;
        }
    }
}