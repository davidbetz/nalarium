#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System;

namespace Nalarium
{
    public class SerializerPair
    {
        //- @Serialize -//
        public Func<object, Type, string> Serialize { get; set; }

        //- @Deserialize -//
        public Func<string, Type, object> Deserialize { get; set; }
    }
}