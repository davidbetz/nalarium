#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using System.ComponentModel;

namespace Nalarium.Configuration.AppConfig
{
    /// <summary>
    /// Represents an element with a comment property.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICommentElement
    {
        //- Comment -//
        /// <summary>
        /// Element comment.
        /// </summary>
        String Comment { get; set; }
    }
}