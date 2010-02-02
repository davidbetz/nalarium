#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
using System.Configuration;
//+
namespace Nalarium.Configuration
{
    /// <summary>
    /// Configuration element with a comment property.
    /// </summary>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public abstract class CommentableElement : ConfigurationElement, ICommentElement
    {
        //- @Comment -//
        /// <summary>
        /// Element comment.
        /// </summary>
        [ConfigurationProperty("comment")]
        public String Comment
        {
            get
            {
                return (String)this["comment"];
            }
            set
            {
                this["comment"] = value;
            }
        }
    }
}