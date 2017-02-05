#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System.Collections.Generic;
using System.ComponentModel;

namespace Nalarium.Configuration.AppConfig
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class WithParameterArrayElement : WithParametersElement, IProvidesParameters
    {
        //- @GetParameterArray -//

        #region IProvidesParameters Members

        public object[] GetParameterArray()
        {
            var parameterArray = new List<object>();
            foreach (var element in Parameters)
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
            foreach (var element in Parameters)
            {
                map.Add(element.Name, element.Value);
            }
            //+
            return map;
        }

        #endregion
    }
}