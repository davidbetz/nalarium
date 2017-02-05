#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System.Globalization;

namespace Nalarium.Activation
{
    public static class InjectedObjectActivator
    {
        //- @Create -//
        /// <summary>
        ///     Used to create an factory from the object factory cache.
        /// </summary>
        /// <param name="objectType">The name of the type to be created</param>
        /// <returns>The created object; null is object type was not found in cache</returns>
        public static object Create(string objectType)
        {
            return Create(objectType, FactoryCache.ObjectFactoryCache);
        }

        /// <summary>
        ///     Used to create a object factory from a specified factory map.
        /// </summary>
        /// <param name="objectType">The name of the type to be created</param>
        /// <param name="objectFactoryMap">The factory cache used to create the type</param>
        /// <returns>The created object; null is object type was not found in cache</returns>
        public static object Create(string objectType, Map<string, IFactory> objectFactoryMap)
        {
            object obj = null;
            if (objectType.Contains(","))
            {
                return ObjectCreator.Create(objectType);
            }
            //+
            if (obj == null && objectFactoryMap != null)
            {
                var processorFactoryList = objectFactoryMap.GetValueList();
                foreach (var factory in processorFactoryList)
                {
                    objectType = objectType.ToLower(CultureInfo.CurrentCulture);
                    obj = ((ObjectFactory) factory).CreateObject(objectType);
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