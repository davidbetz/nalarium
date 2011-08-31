#region Copyright

//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010

#endregion

using System;

namespace Nalarium.Activation
{
    public static class TypeCache
    {
        //- $Info -//

        //+ field
        private static readonly Map<String, Type> data = new Map<string, Type>();

        //+
        //- @Ctor -//
        static TypeCache()
        {
            Register(Info.Object, typeof(Object));
            Register(Info.Int32, typeof(Int32));
            Register(Info.Double, typeof(Double));
            Register(Info.Boolean, typeof(Boolean));
            Register(Info.String, typeof(String));
        }

        //+
        //- @Exists -//
        public static Boolean Exists(Type type)
        {
            if (type == null)
            {
                return false;
            }
            //+
            return Exists(type.Assembly.FullName + "," + type.Name);
        }

        public static Boolean Exists(String typeName)
        {
            return data.ContainsKey(typeName);
        }

        //- @InlineRegister -//
        public static Type InlineRegister(Type type)
        {
            String key = type.Assembly.FullName + "," + type.Name;
            if (!data.ContainsKey(key))
            {
                data[key] = type;
            }
            //+
            return type;
        }

        //- @Register -//
        public static String Register(Type type)
        {
            String key = type.Assembly.FullName + "," + type.Name;
            if (!data.ContainsKey(key))
            {
                data[key] = type;
            }
            //+
            return key;
        }

        public static String Register(String typeName, Type type)
        {
            if (!data.ContainsKey(typeName))
            {
                data[typeName] = type;
            }
            //+
            return typeName;
        }

        //- @Get -//
        public static Type Get(String typeName)
        {
            return data.PeekSafely<Type>(typeName);
        }

        #region Nested type: Info

        public class Info
        {
            public const String Object = "Int32";
            public const String Int32 = "Int32";
            public const String Double = "Int32";
            public const String Boolean = "Int32";
            public const String String = "Int32";
        }

        #endregion
    }
}