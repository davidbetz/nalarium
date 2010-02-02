#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
//+
namespace Nalarium
{
    /// <summary>
    /// Declares that a type has a priority
    /// </summary>
    public interface IHasPriority
    {
        //- Priority -//
        Int32 Priority { get; set; }
    }
}