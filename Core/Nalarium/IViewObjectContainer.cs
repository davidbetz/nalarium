﻿#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;

namespace Nalarium
{
    public interface IViewObjectContainer
    {
        Map<String, Object> ViewObjectMap { get; set; }
    }
}