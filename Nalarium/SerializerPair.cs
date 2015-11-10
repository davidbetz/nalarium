#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

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