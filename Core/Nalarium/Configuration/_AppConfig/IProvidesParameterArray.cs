#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
//+
namespace Nalarium.Configuration
{
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public interface IProvidesParameters
    {
        //- GetParameterArray -//
        Object[] GetParameterArray();

        //- GetParameterMap -//
        Map GetParameterMap();
    }
}