#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System.ComponentModel;
using System.Configuration;

namespace Nalarium.Configuration.AppConfig
{
    /// <summary>
    ///     Configuration element with a comment property.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class CommentableElement : ConfigurationElement, ICommentElement
    {
        //- @Comment -//

        #region ICommentElement Members

        /// <summary>
        ///     Element comment.
        /// </summary>
        [ConfigurationProperty("comment")]
        public string Comment
        {
            get { return (string) this["comment"]; }
            set { this["comment"] = value; }
        }

        #endregion
    }
}