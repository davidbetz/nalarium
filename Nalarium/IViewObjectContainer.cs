﻿#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

namespace Nalarium
{
    public interface IViewObjectContainer
    {
        Map<string, object> ViewObjectMap { get; set; }
    }
}