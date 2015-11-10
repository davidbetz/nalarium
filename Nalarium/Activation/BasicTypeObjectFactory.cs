#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;

namespace Nalarium.Activation
{
    public class BasicTypeObjectFactory : TypeFactory
    {
        //- @CreateObject -//
        public override Type CreateType(String text)
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