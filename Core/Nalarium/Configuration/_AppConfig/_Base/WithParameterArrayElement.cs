#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
//+
namespace Nalarium.Configuration
{
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public abstract class WithParameterArrayElement : WithParametersElement, IProvidesParameters
    {
        //- @GetParameterArray -//
        public Object[] GetParameterArray()
        {
            System.Collections.Generic.List<Object> parameterArray = new System.Collections.Generic.List<Object>();
            foreach (ParameterElement element in Parameters)
            {
                parameterArray.Add(element.Value);
            }
            //+
            return parameterArray.ToArray();
        }

        //- @GetParameterMap -//
        public Map GetParameterMap()
        {
            Map map = new Map();
            foreach (ParameterElement element in Parameters)
            {
                map.Add(element.Name, element.Value);
            }
            //+
            return map;
        }
    }
}