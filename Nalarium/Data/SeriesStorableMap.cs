#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System.Text;

namespace Nalarium.Data
{
    /// <summary>
    ///     Represents a map that allows loading and saving of its data as a series of data.
    /// </summary>
    public abstract class SeriesStorableMap : ScopedMap, IStorable
    {
        //- @ScopeSplitter -//
        public abstract string ScopeSplitter { get; }

        //- @KeyValueSplitter -//
        public abstract char KeyValueSplitter { get; }

        //- @ItemSplitter -//
        public abstract char ItemSplitter { get; }

        //- #DecodeValue -//
        protected virtual string DecodeValue(string data)
        {
            return data;
        }

        //- #EncodeValue -//
        protected virtual string EncodeValue(string data)
        {
            return data;
        }

        //+
        //- @Load -//

        #region IStorable Members

        /// <summary>
        ///     Loads the specified query string data.
        /// </summary>
        /// <param name="base64Data">The base64 data.</param>
        public virtual void Load(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                var itemArray = data.Split(ItemSplitter);
                //+
                foreach (var item in itemArray)
                {
                    var keyValueArray = item.Split(KeyValueSplitter);
                    if (keyValueArray.Length == 2)
                    {
                        var key = keyValueArray[0].Replace(ScopeSplitter, "::");
                        Add(key, DecodeValue(keyValueArray[1]));
                    }
                }
            }
        }

        //- @Save -//
        /// <summary>
        ///     Saves this instance.
        /// </summary>
        /// <returns></returns>
        public virtual string Save()
        {
            var data = new StringBuilder();
            //+
            var first = true;
            var keyList = GetKeyList();
            foreach (var key in keyList)
            {
                if (!first)
                {
                    data.Append(ItemSplitter);
                }
                first = false;
                var storableKey = key.Replace("::", ScopeSplitter);
                data.Append(storableKey + KeyValueSplitter + EncodeValue(this[key]));
            }
            //+
            return data.ToString();
        }

        #endregion
    }
}