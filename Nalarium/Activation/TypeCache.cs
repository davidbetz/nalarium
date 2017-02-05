#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System;

namespace Nalarium.Activation
{
    public static class TypeCache
    {
        //- $Info -//

        //+ field
        private static readonly Map<string, Type> data = new Map<string, Type>();

        //+
        //- @Ctor -//
        static TypeCache()
        {
            Register(Info.Object, typeof (object));
            Register(Info.Int32, typeof (int));
            Register(Info.Double, typeof (double));
            Register(Info.Boolean, typeof (bool));
            Register(Info.String, typeof (string));
        }

        //+
        //- @Exists -//
        public static bool Exists(Type type)
        {
            if (type == null)
            {
                return false;
            }
            //+
            return Exists(type.Assembly.FullName + "," + type.Name);
        }

        public static bool Exists(string typeName)
        {
            return data.ContainsKey(typeName);
        }

        //- @InlineRegister -//
        public static Type InlineRegister(Type type)
        {
            var key = type.Assembly.FullName + "," + type.Name;
            if (!data.ContainsKey(key))
            {
                data[key] = type;
            }
            //+
            return type;
        }

        //- @Register -//
        public static string Register(Type type)
        {
            var key = type.Assembly.FullName + "," + type.Name;
            if (!data.ContainsKey(key))
            {
                data[key] = type;
            }
            //+
            return key;
        }

        public static string Register(string typeName, Type type)
        {
            if (!data.ContainsKey(typeName))
            {
                data[typeName] = type;
            }
            //+
            return typeName;
        }

        //- @Get -//
        public static Type Get(string typeName)
        {
            return data.Get<Type>(typeName);
        }

        #region Nested type: Info

        public class Info
        {
            public const string Object = "Int32";
            public const string Int32 = "Int32";
            public const string Double = "Int32";
            public const string Boolean = "Int32";
            public const string String = "Int32";
        }

        #endregion
    }
}