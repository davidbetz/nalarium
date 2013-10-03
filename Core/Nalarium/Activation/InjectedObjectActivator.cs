#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using System.Collections.Generic;
using System.Globalization;

namespace Nalarium.Activation
{
    public static class InjectedObjectActivator
    {
        //- @Create -//
        /// <summary>
        /// Used to create an factory from the object factory cache.
        /// </summary>
        /// <param name="objectType">The name of the type to be created</param>
        /// <returns>The created object; null is object type was not found in cache</returns>
        public static Object Create(String objectType)
        {
            return Create(objectType, FactoryCache.ObjectFactoryCache);
        }

        /// <summary>
        /// Used to create a object factory from a specified factory map.
        /// </summary>
        /// <param name="objectType">The name of the type to be created</param>
        /// <param name="objectFactoryMap">The factory cache used to create the type</param>
        /// <returns>The created object; null is object type was not found in cache</returns>
        public static Object Create(String objectType, Map<String, IFactory> objectFactoryMap)
        {
            Object obj = null;
            if (objectType.Contains(","))
            {
                return ObjectCreator.Create(objectType);
            }
            //+
            if (obj == null && objectFactoryMap != null)
            {
                List<IFactory> processorFactoryList = objectFactoryMap.GetValueList();
                foreach (IFactory factory in processorFactoryList)
                {
                    objectType = objectType.ToLower(CultureInfo.CurrentCulture);
                    obj = ((ObjectFactory)factory).CreateObject(objectType);
                    if (obj != null)
                    {
                        break;
                    }
                }
            }
            //+
            return obj;
        }
    }
}