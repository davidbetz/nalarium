﻿#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System.Collections.Generic;
using System.ComponentModel;
using Nalarium.Configuration.AppConfig.Parameter;

namespace Nalarium.Configuration.AppConfig
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class WithParameterArrayElement : WithParametersElement, IProvidesParameters
    {
        //- @GetParameterArray -//

        #region IProvidesParameters Members

        public System.Object[] GetParameterArray()
        {
            var parameterArray = new List<object>();
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
            var map = new Map();
            foreach (ParameterElement element in Parameters)
            {
                map.Add(element.Name, element.Value);
            }
            //+
            return map;
        }

        #endregion
    }
}