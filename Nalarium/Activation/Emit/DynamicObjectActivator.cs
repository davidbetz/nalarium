#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Nalarium.Activation.Emit
{
    /// <summary>
    ///     Creates an instance of a type using dynamic emit.
    /// </summary>
    public class DynamicObjectActivator
    {
        //- $MethodCreator -//

        //+ field
        private static string _methodCreatorTypeKey;

        //+
        //- @TypeMap -//
        /// <summary>
        ///     Map representing types.
        /// </summary>
        public static Map<string, Type> TypeMap = new Map<string, Type>();

        //+
        //- @Create -//
        /// <summary>
        ///     Creates an instance of a type.
        /// </summary>
        /// <typeparam name="T">Type of the type to create.</typeparam>
        /// <param name="typeName">Name of the type to create.</param>
        /// <returns>Instance of the type.</returns>
        public static T Create<T>(string typeName)
        {
            return (T) Create(typeName);
        }

        /// <summary>
        ///     Creates an instance of a type.
        /// </summary>
        /// <param name="typeName">Name of the type to create.</param>
        /// <returns>Instance of the type.</returns>
        public static object Create(string typeName)
        {
            var type = TypeCache.Get(typeName);
            if (type == null)
            {
                return null;
            }
            var info = type.GetConstructor(Type.EmptyTypes);
            var runnerCreator = InitializeDynamicMethod(type, info);
            //+
            return runnerCreator();
        }

        /// <summary>
        ///     Creates an instance of a type.
        /// </summary>
        /// <typeparam name="T">Type of the type to create.</typeparam>
        /// <param name="type">Type of the type to create.</param>
        /// <returns>Instance of the type.</returns>
        public static T Create<T>(Type type)
        {
            return (T) Create(type);
        }

        /// <summary>
        ///     Creates an instance of a type.
        /// </summary>
        /// <param name="type">Type of the type to create.</param>
        /// <returns>Instance of the type.</returns>
        public static object Create(Type type)
        {
            var info = type.GetConstructor(Type.EmptyTypes);
            var runnerCreator = InitializeDynamicMethod(type, info);
            //+
            return runnerCreator();
        }

        //- $InitializeDynamicMethod -//
        private static MethodCreator InitializeDynamicMethod(Type type, ConstructorInfo info)
        {
            if (string.IsNullOrEmpty(_methodCreatorTypeKey))
            {
                _methodCreatorTypeKey = TypeCache.Register(typeof (MethodCreator));
            }
            var dynamic = new DynamicMethod(string.Empty, TypeCache.Get(TypeCache.Info.Object), Type.EmptyTypes, type);
            var il = dynamic.GetILGenerator();
            il.DeclareLocal(type);
            il.Emit(OpCodes.Newobj, info);
            il.Emit(OpCodes.Ret);
            //+
            return dynamic.CreateDelegate(TypeCache.Get(_methodCreatorTypeKey)) as MethodCreator;
        }

        #region Nested type: MethodCreator

        private delegate object MethodCreator();

        #endregion
    }
}