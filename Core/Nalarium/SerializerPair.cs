#region Copyright

//+ Nalarium Pro 3.0 - Core Module
//+ Copyright � Jampad Technology, Inc. 2007-2010

#endregion

using System;

namespace Nalarium
{
    public class SerializerPair
    {
        //- @Serialize -//
        public Func<Object, Type, String> Serialize { get; set; }

        //- @Deserialize -//
        public Func<String, Type, Object> Deserialize { get; set; }
    }
}