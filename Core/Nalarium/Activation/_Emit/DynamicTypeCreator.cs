#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace Nalarium.Activation
{
    /// <summary>
    /// Dynamically creates a type.
    /// </summary>
    public static class DynamicTypeCreator
    {
        private static readonly Type _type = typeof(DynamicTypeCreator);
        private static readonly Object _lock = new Object();
        private static readonly Map<String, TypeBuilder> _typeBuilderCache = new Map<String, TypeBuilder>();
        //+
        private static AssemblyName _assemblyName;
        private static AssemblyBuilder _assemblyBuilder;
        private static ModuleBuilder _moduleBuilder;

        //+
        //- @CreateInstance -//
        /// <summary>
        /// Creates an instance of a type.
        /// </summary>
        /// <param name="builder">TypeBuilder instance used to create a type.</param>
        /// <returns>Instance of the type.</returns>
        public static Object CreateInstance(TypeBuilder builder)
        {
            return CreateInstance(builder.CreateType());
        }

        /// <summary>
        /// Creates an instance of a type.
        /// </summary>
        /// <param name="name">Name of the type to be created.</param>
        /// <param name="propertyMap">Map of all properties to be placed in the type.</param>
        /// <returns>Instance of the type.</returns>
        public static Object CreateInstance(String name, Map<String, Type> propertyMap)
        {
            return CreateInstance(DefineTypeBuilder(name, propertyMap));
        }

        /// <summary>
        /// Creates an instance of a type.
        /// </summary>
        /// <param name="name">Name of the type to be created.</param>
        /// <param name="parameterArray">Array of all properties to tbe placed in the type.</param>
        /// <returns>Instance of the type.</returns>
        public static Object CreateInstance(String name, params PropertyDataBase[] parameterArray)
        {
            return CreateInstance(name, new List<PropertyDataBase>(parameterArray));
        }

        /// <summary>
        /// Creates an instance of a type.
        /// </summary>
        /// <param name="name">Name of the type to be created.</param>
        /// <param name="propertyList">List of all properties to tbe placed in the type.</param>
        /// <returns>Instance of the type.</returns>
        public static Object CreateInstance(String name, List<PropertyDataBase> propertyList)
        {
            if (propertyList == null)
            {
                propertyList = new List<PropertyDataBase>();
            }
            Type type = DefineTypeBuilder(name, propertyList).CreateType();
            Object instance = CreateInstance(type);
            //+ populate
            propertyList.ForEach(p =>
                                 {
                                     PropertyInfo targetPropertyInfo = type.GetProperty(p.Name);
                                     PropertyInfo sourcePropertyInfo = p.GetType().GetProperty("Value");
                                     //+
                                     targetPropertyInfo.SetValue(instance, sourcePropertyInfo.GetValue(p, null), null);
                                 });
            //+
            return instance;
        }

        //- @DefineTypeBuilder -//
        /// <summary>
        /// Defines a TypeBuilder by name and parameter map.
        /// </summary>
        /// <param name="name">Name of the type to be created.</param>
        /// <param name="propertyMap">Map of all properties to be placed in the type.</param>
        /// <returns>Type builder that may be used to create the type.</returns>
        public static TypeBuilder DefineTypeBuilder(String name, Map<String, Type> propertyMap)
        {
            if (propertyMap == null)
            {
                propertyMap = new Map<String, Type>();
            }
            var propertyList = new List<PropertyDataBase>();
            //+ convert
            foreach (String propertyName in propertyMap.Keys)
            {
                propertyList.Add(PropertyDataCreator.Create(propertyName, propertyMap[propertyName]));
            }
            //+
            return DefineTypeBuilder(name, propertyList);
        }

        /// <summary>
        /// Defines a TypeBuilder by name and parameter map.
        /// </summary>
        /// <param name="name">Name of the type to be created.</param>
        /// <param name="propertyList">List of all properties to tbe placed in the type.</param>
        /// <returns>Type builder that may be used to create the type.</returns>
        public static TypeBuilder DefineTypeBuilder(String name, List<PropertyDataBase> propertyList)
        {
            if (propertyList == null)
            {
                propertyList = new List<PropertyDataBase>();
            }
            lock (_lock)
            {
                if (_typeBuilderCache.ContainsKey(name))
                {
                    return _typeBuilderCache[name];
                }
                if (_assemblyName == null)
                {
                    _assemblyName = new AssemblyName("_Assembly" + _type.GetHashCode());
                    _assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(_assemblyName, AssemblyBuilderAccess.Run);
                    _moduleBuilder = _assemblyBuilder.DefineDynamicModule("_Module");
                }
                //+
                _typeBuilderCache.Add(name, _moduleBuilder.DefineType(name, TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass | TypeAttributes.AnsiClass | TypeAttributes.BeforeFieldInit | TypeAttributes.AutoLayout, typeof(Object)));
                //+ property series
                propertyList.ForEach(p => CreateProperty(_typeBuilderCache[name], p.Name, p.Type));
                //+
                return _typeBuilderCache[name];
            }
        }

        //- @RemoveTypeBuilderFromCache -//
        /// <summary>
        /// Removes a previously created type builder from cache.
        /// </summary>
        /// <param name="name">Name of type.</param>
        public static void RemoveTypeBuilderFromCache(String name)
        {
            lock (_lock)
            {
                if (_typeBuilderCache.ContainsKey(name))
                {
                    _typeBuilderCache.Remove(name);
                }
            }
        }

        //- @ResetCache -//
        /// <summary>
        /// Removes all previously created type builders from cache.
        /// </summary>
        public static void ResetCache()
        {
            lock (_lock)
            {
                _typeBuilderCache.Clear();
            }
        }

        //+ private
        //- $CreateInstance -//
        private static Object CreateInstance(Type type)
        {
            return Activator.CreateInstance(type);
        }

        //- $CreateProperty -//
        private static void CreateProperty(TypeBuilder typeBuilder, String name, Type type)
        {
            PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(name, PropertyAttributes.None, type, null);
            MethodAttributes methodAttribute = MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig;
            FieldBuilder fieldBuilder = typeBuilder.DefineField(name, type, FieldAttributes.Private);
            //+
            MethodBuilder getMethodBuilder = typeBuilder.DefineMethod("get_" + name, methodAttribute, type, Type.EmptyTypes);
            ILGenerator generator = getMethodBuilder.GetILGenerator();
            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldfld, fieldBuilder);
            generator.Emit(OpCodes.Ret);
            //+
            MethodBuilder setMethodBuilder = typeBuilder.DefineMethod("set_" + name, methodAttribute, null, new[]
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