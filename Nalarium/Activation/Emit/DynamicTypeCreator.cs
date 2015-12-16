#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace Nalarium.Activation.Emit
{
    /// <summary>
    ///     Dynamically creates a type.
    /// </summary>
    public static class DynamicTypeCreator
    {
        //private static readonly Map<String, TypeBuilder> _typeBuilderCache = new Map<String, TypeBuilder>();
        //+

        //+
        //- @CreateInstance -//
        /// <summary>
        ///     Creates an instance of a type.
        /// </summary>
        /// <param name="builder">TypeBuilder instance used to create a type.</param>
        /// <returns>Instance of the type.</returns>
        public static object CreateInstance(TypeBuilder builder)
        {
            return CreateInstance(builder.CreateType());
        }

        /// <summary>
        ///     Creates an instance of a type.
        /// </summary>
        /// <param name="name">Name of the type to be created.</param>
        /// <param name="propertyMap">Map of all properties to be placed in the type.</param>
        /// <returns>Instance of the type.</returns>
        public static object CreateInstance(string name, Map<string, Type> propertyMap)
        {
            return CreateInstance(DefineTypeBuilder(name, propertyMap));
        }

        /// <summary>
        ///     Creates an instance of a type.
        /// </summary>
        /// <param name="name">Name of the type to be created.</param>
        /// <param name="parameterArray">Array of all properties to tbe placed in the type.</param>
        /// <returns>Instance of the type.</returns>
        public static object CreateInstance(string name, params PropertyDataBase[] parameterArray)
        {
            return CreateInstance(name, new List<PropertyDataBase>(parameterArray));
        }

        /// <summary>
        ///     Creates an instance of a type.
        /// </summary>
        /// <param name="name">Name of the type to be created.</param>
        /// <param name="propertyList">List of all properties to tbe placed in the type.</param>
        /// <returns>Instance of the type.</returns>
        public static object CreateInstance(string name, List<PropertyDataBase> propertyList)
        {
            if (propertyList == null)
            {
                propertyList = new List<PropertyDataBase>();
            }
            var type = DefineTypeBuilder(name, propertyList).CreateType();
            var instance = CreateInstance(type);
            //+ populate
            propertyList.ForEach(p =>
            {
                var targetPropertyInfo = type.GetProperty(p.Name);
                var sourcePropertyInfo = p.GetType().GetProperty("Value");
                //+
                targetPropertyInfo.SetValue(instance, sourcePropertyInfo.GetValue(p, null), null);
            });
            //+
            return instance;
        }

        //- @DefineTypeBuilder -//
        /// <summary>
        ///     Defines a TypeBuilder by name and parameter map.
        /// </summary>
        /// <param name="name">Name of the type to be created.</param>
        /// <param name="propertyMap">Map of all properties to be placed in the type.</param>
        /// <returns>Type builder that may be used to create the type.</returns>
        public static TypeBuilder DefineTypeBuilder(string name, Map<string, Type> propertyMap)
        {
            if (propertyMap == null)
            {
                propertyMap = new Map<string, Type>();
            }
            var propertyList = new List<PropertyDataBase>();
            //+ convert
            foreach (var propertyName in propertyMap.Keys)
            {
                propertyList.Add(PropertyDataCreator.Create(propertyName, propertyMap[propertyName]));
            }
            //+
            return DefineTypeBuilder(name, propertyList);
        }


        /// <summary>
        ///     Defines a TypeBuilder by name and parameter map.
        /// </summary>
        /// <param name="name">Name of the type to be created.</param>
        /// <param name="propertyList">List of all properties to tbe placed in the type.</param>
        /// <param name="parameterArray">List of all interfaces to be implemented on the type.</param>
        /// <returns>Type builder that may be used to create the type.</returns>
        public static TypeBuilder DefineTypeBuilder(string name, List<PropertyDataBase> propertyList, params Type[] parameterArray)
        {
            return DefineTypeBuilder(name, propertyList, parameterArray, false);
        }

        /// <summary>
        ///     Defines a TypeBuilder by name and parameter map.
        /// </summary>
        /// <param name="name">Name of the type to be created.</param>
        /// <param name="propertyList">List of all properties to tbe placed in the type.</param>
        /// <param name="parameterAray">List of all interfaces to be implemented on the type.</param>
        /// <param name="doNotAddInterfaceProperties">True when interface properties should not be implemented automatically.</param>
        /// <returns>Type builder that may be used to create the type.</returns>
        public static TypeBuilder DefineTypeBuilder(string name, List<PropertyDataBase> propertyList, Type[] parameterArray = null, bool doNotAddInterfaceProperties = false)
        {
            if (propertyList == null)
            {
                propertyList = new List<PropertyDataBase>();
            }
            //if (_typeBuilderCache.ContainsKey(name))
            //{
            //    return _typeBuilderCache[name];
            //}
            var guid = GuidCreator.GetNewGuid();
            var assemblyName = new AssemblyName("_Assembly" + guid);
            var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule("_Module" + guid);
            var typeBuilder = moduleBuilder.DefineType(name, TypeAttributes.Public | TypeAttributes.Class, typeof (object));
            //++ interface
            if (parameterArray != null)
            {
                foreach (var interfaceType in parameterArray)
                {
                    typeBuilder.AddInterfaceImplementation(interfaceType);
                    if (!doNotAddInterfaceProperties)
                    {
                        var interfacePropertyData = interfaceType.GetProperties();
                        foreach (var interfaceProperty in interfacePropertyData)
                        {
                            var attributeTypeData = (from a in interfaceProperty.GetCustomAttributes(false)
                                let s = a as EmitMarkerAttribute
                                where s != null && s.AttributeType != null
                                select s.AttributeType).ToList();
                            CreateProperty(typeBuilder, interfaceProperty.Name, interfaceProperty.PropertyType, attributeTypeData);
                        }
                    }
                }
            }
            //+ property series
            propertyList.ForEach(p => CreateProperty(typeBuilder, p.Name, p.Type, null));
            //+
            return typeBuilder;
            ////+
            //_typeBuilderCache.Add(name, _moduleBuilder.DefineType(name, TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass | TypeAttributes.AnsiClass | TypeAttributes.BeforeFieldInit | TypeAttributes.AutoLayout, typeof(Object)));
            ////+ property series
            //propertyList.ForEach(p => CreateProperty(_typeBuilderCache[name], p.Name, p.Type));
            ////+
            //return _typeBuilderCache[name];
        }

        ////- @RemoveTypeBuilderFromCache -//
        ///// <summary>
        ///// Removes a previously created type builder from cache.
        ///// </summary>
        ///// <param name="name">Name of type.</param>
        //public static void RemoveTypeBuilderFromCache(String name)
        //{
        //    lock (_lock)
        //    {
        //        if (_typeBuilderCache.ContainsKey(name))
        //        {
        //            _typeBuilderCache.Remove(name);
        //        }
        //    }
        //}

        ////- @ResetCache -//
        ///// <summary>
        ///// Removes all previously created type builders from cache.
        ///// </summary>
        //public static void ResetCache()
        //{
        //    lock (_lock)
        //    {
        //        _typeBuilderCache.Clear();
        //    }
        //}

        //+ private
        //- $CreateInstance -//
        private static object CreateInstance(Type type)
        {
            return Activator.CreateInstance(type);
        }

        //- $CreateProperty -//
        private static void CreateProperty(TypeBuilder typeBuilder, string name, Type type, IEnumerable<Type> attributeTypeArray)
        {
            var propertyBuilder = typeBuilder.DefineProperty(name, PropertyAttributes.None, type, null);
            if (attributeTypeArray != null)
            {
                foreach (var attributeType in attributeTypeArray)
                {
                    propertyBuilder.SetCustomAttribute(new CustomAttributeBuilder(attributeType.GetConstructor(new Type[] {}), new object[] {}));
                }
            }
            const MethodAttributes methodAttribute = MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.Virtual;
            var fieldBuilder = typeBuilder.DefineField(name, type, FieldAttributes.Private);
            //+
            var getMethodBuilder = typeBuilder.DefineMethod("get_" + name, methodAttribute, type, Type.EmptyTypes);
            var generator = getMethodBuilder.GetILGenerator();
            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldfld, fieldBuilder);
            generator.Emit(OpCodes.Ret);
            //+
            var setMethodBuilder = typeBuilder.DefineMethod("set_" + name, methodAttribute, null, new[]
            {
                type
            });
            generator = setMethodBuilder.GetILGenerator();
            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldarg_1);
            generator.Emit(OpCodes.Stfld, fieldBuilder);
            generator.Emit(OpCodes.Ret);
            //+
            propertyBuilder.SetGetMethod(getMethodBuilder);
            propertyBuilder.SetSetMethod(setMethodBuilder);
        }
    }
}