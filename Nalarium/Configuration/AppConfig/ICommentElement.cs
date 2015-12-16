#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System.ComponentModel;

namespace Nalarium.Configuration.AppConfig
{
    /// <summary>
    ///     Represents an element with a comment property.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICommentElement
    {
        //- Comment -//
        /// <summary>
        ///     Element comment.
        /// </summary>
        string Comment { get; set; }
    }
}