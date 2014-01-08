#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;

namespace Nalarium.Configuration.AppConfig
{
    /// <summary>
    /// Presents a configuration collection that has a comment property.
    /// </summary>
    /// <typeparam name="T">Type of comment element; must be of type CommentableElement.</typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class CommentableCollection<T> : ConfigurationElementCollection, IEnumerable<T>
        where T : CommentableElement, new()
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

        //- @[Indexer] -//
        public T this[Int32 index]
        {
            get
            {
                return base.BaseGet(index) as T;
            }
        }

        //- #CreateNewElement -//

        //- #ElementName -//
        protected override String ElementName
        {
            get
            {
                return "add";
            }
        }

        //- #IsElementName -//

        //- @CollectionType -//
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        //- @GetEnumerator -//

        #region IEnumerable<T> Members

        public new IEnumerator<T> GetEnumerator()
        {
            for (Int32 i = 0; i < base.Count; i++)
            {
                yield return this[i];
            }
        }

        #endregion

        protected override ConfigurationElement CreateNewElement()
        {
            return new T();
        }

        protected override Boolean IsElementName(String elementName)
        {
            return !String.IsNullOrEmpty(elementName) && elementName == ElementName;
        }
    }
}