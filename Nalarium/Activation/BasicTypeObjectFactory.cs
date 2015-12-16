#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System;

namespace Nalarium.Activation
{
    public class BasicTypeObjectFactory : TypeFactory
    {
        //- @CreateObject -//
        public override Type CreateType(string text)
        {
            Type ex = null;
            switch (text)
            {
                case "int32":
                case "int":
                case "integer":
                    return TypeCache.Get(TypeCache.Info.Int32);
                case "double":
                    return TypeCache.Get(TypeCache.Info.Double);
                case "bool":
                case "boolean":
                    return TypeCache.Get(TypeCache.Info.Boolean);
                case "string":
                    return TypeCache.Get(TypeCache.Info.String);
            }
            //+
            return ex;
        }
    }
}