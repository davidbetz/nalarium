#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;

namespace Nalarium.Configuration.AppConfig
{
    /// <summary>
    ///     Presents a configuration collection that has a comment property.
    /// </summary>
    /// <typeparam name="T">Type of comment element; must be of type CommentableElement.</typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class CommentableCollection<T> : ConfigurationElementCollection, IEnumerable<T>
        where T : CommentableElement, new()
    {
        //- @Comment -//
        /// <summary>
        ///     Element comment.
        /// </summary>
        [ConfigurationProperty("comment")]
        public string Comment
        {
            get { return (string) this["comment"]; }
            set { this["comment"] = value; }
        }

        //- @[Indexer] -//
        public T this[int index]
        {
            get { return BaseGet(index) as T; }
        }

        //- #CreateNewElement -//

        //- #ElementName -//
        protected override string ElementName
        {
            get { return "add"; }
        }

        //- #IsElementName -//

        //- @CollectionType -//
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        //- @GetEnumerator -//

        #region IEnumerable<T> Members

        public new IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }

        #endregion

        protected override ConfigurationElement CreateNewElement()
        {
            return new T();
        }

        protected override bool IsElementName(string elementName)
        {
            return !string.IsNullOrEmpty(elementName) && elementName == ElementName;
        }
    }
}