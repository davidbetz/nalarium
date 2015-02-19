﻿#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;

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