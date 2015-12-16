#region Copyright

//+ Copyright � David Betz 2007-2015

#endregion

using System;

namespace Nalarium.Activation.Emit
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class EmitMarkerAttribute : Attribute
    {
        public abstract Type AttributeType { get; }
    }
}