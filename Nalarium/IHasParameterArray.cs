#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

namespace Nalarium
{
    /// <summary>
    ///     Declares that a type has a parameter array
    /// </summary>
    public interface IHasParameterArray
    {
        //- ParameterArray -//
        /// <summary>
        ///     Gets or sets the parameter array.
        /// </summary>
        /// <value>The parameter array.</value>
        object[] ParameterArray { get; set; }
    }
}