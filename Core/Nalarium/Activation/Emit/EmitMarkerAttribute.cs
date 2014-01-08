using System;

namespace Nalarium.Activation.Emit
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class EmitMarkerAttribute : Attribute
    {
        public abstract Type AttributeType { get; }
    }
}