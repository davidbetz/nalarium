using System;
using System.Xml.Serialization;

namespace Nalarium.Activation.Emit
{
    [AttributeUsage(AttributeTargets.Property)]
    public class XmlIgnoreEmitMarkerAttribute : EmitMarkerAttribute
    {
        public override Type AttributeType => typeof (XmlIgnoreAttribute);
    }
}