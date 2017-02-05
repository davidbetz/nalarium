#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

//+
namespace Nalarium
{
    /// <summary>
    ///     Declares that a type has a parameter map
    /// </summary>
    public interface IHasParameterMap
    {
        //- ParameterMap -//
        /// <summary>
        ///     Gets or sets the parameter map.
        /// </summary>
        /// <value>The parameter map.</value>
        Map ParameterMap { get; set; }

        //- @DefaultParameter -//
        /// <summary>
        ///     Name of the default parameter.
        /// </summary>
        string DefaultParameter { get; set; }
    }
}