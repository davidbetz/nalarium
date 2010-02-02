#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
using System.Collections.Generic;
using System.Configuration;
//+
namespace Nalarium.Configuration
{
    /// <summary>
    /// Presents a configuration collection that has a comment property.
    /// </summary>
    /// <typeparam name="T">Type of comment element; must be of type CommentableElement.</typeparam>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
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
        protected override ConfigurationElement CreateNewElement()
        {
            return new T();
        }

        //- #ElementName -//
        protected override String ElementName
        {
            get
            {
                return "add";
            }
        }

        //- #IsElementName -//
        protected override Boolean IsElementName(String elementName)
        {
            return !String.IsNullOrEmpty(elementName) && elementName == this.ElementName;
        }

        //- @CollectionType -//
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        #region IEnumerable<T> Members

        //- @GetEnumerator -//
        public new IEnumerator<T> GetEnumerator()
        {
            for (Int32 i = 0; i < base.Count; i++)
            {
                yield return (T)this[i];
            }
        }

        #endregion
    }
}