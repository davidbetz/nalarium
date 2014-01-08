using System;

namespace Nalarium.Activation.Emit
{
    [AttributeUsage(AttributeTargets.Property)]
    public class XmlIgnoreEmitMarkerAttribute : EmitMarkerAttribute
    {
        public override Type AttributeType
        {
            get
            {
                return typeof(System.Xml.Serialization.XmlIgnoreAttribute);
            }
        }
    }
}