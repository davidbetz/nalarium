#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
//+
namespace Nalarium.Configuration
{
    /// <summary>
    /// Represents an element with a comment property.
    /// </summary>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public interface ICommentElement
    {
        //- Comment -//
        /// <summary>
        /// Element comment.
        /// </summary>
        String Comment { get; set; }
    }
}