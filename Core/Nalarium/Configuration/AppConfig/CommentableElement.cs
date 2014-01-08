#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using System.ComponentModel;
using System.Configuration;

namespace Nalarium.Configuration.AppConfig
{
    /// <summary>
    /// Configuration element with a comment property.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class CommentableElement : ConfigurationElement, ICommentElement
    {
        //- @Comment -//

        #region ICommentElement Members

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

        #endregion
    }
}