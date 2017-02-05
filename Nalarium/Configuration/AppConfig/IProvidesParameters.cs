#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System.ComponentModel;

namespace Nalarium.Configuration.AppConfig
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IProvidesParameters
    {
        //- GetParameterArray -//
        object[] GetParameterArray();

        //- GetParameterMap -//
        Map GetParameterMap();
    }
}