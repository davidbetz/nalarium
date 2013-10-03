#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using System.ComponentModel;

namespace Nalarium.Configuration
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IProvidesParameters
    {
        //- GetParameterArray -//
        Object[] GetParameterArray();

        //- GetParameterMap -//
        Map GetParameterMap();
    }
}