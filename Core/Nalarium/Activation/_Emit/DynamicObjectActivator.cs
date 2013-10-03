#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Nalarium.Activation
{
    /// <summary>
    /// Creates an instance of a type using dynamic emit.
    /// </summary>
    public class DynamicObjectActivator
    {
        //- $MethodCreator -//

        //+ field
        private static Object _lock = new Object();
        private static String _methodCreatorTypeKey;

        //+
        //- @TypeMap -//
        /// <summary>
        /// Map representing types.
        /// </summary>
        public static Map<String, Type> TypeMap = new Map<String, Type>();

        //+
        //- @Create -//
        /// <summary>
        /// Creates an instance of a type.
        /// </summary>
        /// <typeparam name="T">Type of the type to create.</typeparam>
        /// <param name="typeName">Name of the type to create.</param>
        /// <returns>Instance of the type.</returns>
        public static T Create<T>(String typeName)
        {
            return (T)Create(typeName);
        }

        /// <summary>
        /// Creates an instance of a type.
        /// </summary>
        /// <param name="typeName">Name of the type to create.</param>
        /// <returns>Instance of the type.</returns>
        public static Object Create(String typeName)
        {
            Type type = TypeCache.Get(typeName);
            if (type == null)
            {
                return null;
            }
            ConstructorInfo info = type.GetConstructor(Type.EmptyTypes);
            MethodCreator runnerCreator = InitializeDynamicMethod(type, info);
            //+
            return runnerCreator();
        }

        /// <summary>
        /// Creates an instance of a type.
        /// </summary>
        /// <typeparam name="T">Type of the type to create.</typeparam>
        /// <param name="type">Type of the type to create.</param>
        /// <returns>Instance of the type.</returns>
        public static T Create<T>(Type type)
        {
            return (T)Create(type);
        }

        /// <summary>
        /// Creates an instance of a type.
        /// </summary>
        /// <param name="type">Type of the type to create.</param>
        /// <returns>Instance of the type.</returns>
        public static Object Create(Type type)
        {
            ConstructorInfo info = type.GetConstructor(Type.EmptyTypes);
            MethodCreator runnerCreator = InitializeDynamicMethod(type, info);
            //+
            return runnerCreator();
        }

        //- $InitializeDynamicMethod -//
        private static MethodCreator InitializeDynamicMethod(Type type, ConstructorInfo info)
        {
            if (String.IsNullOrEmpty(_methodCreatorTypeKey))
            {
                _methodCreatorTypeKey = TypeCache.Register(typeof(MethodCreator));
            }
            var dynamic = new DynamicMethod(string.Empty, TypeCache.Get(TypeCache.Info.Object), Type.EmptyTypes, type);
            ILGenerator il = dynamic.GetILGenerator();
            il.DeclareLocal(type);
            il.Emit(OpCodes.Newobj, info);
            il.Emit(OpCodes.Ret);
            //+
            return dynamic.CreateDelegate(TypeCache.Get(_methodCreatorTypeKey)) as MethodCreator;
        }

        #region Nested type: MethodCreator

        private delegate Object MethodCreator();

        #endregion
    }
}