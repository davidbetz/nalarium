#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
using System.Collections.Generic;
using System.Text;
//+
namespace Nalarium.Data
{   
    /// <summary>
    /// Represents a map that allows loading and saving of its data as a series of data.
    /// </summary>
    public abstract class SeriesStorableMap : ScopedMap, IStorable
    {
        //- @ScopeSplitter -//
        public abstract String ScopeSplitter { get; }

        //- @KeyValueSplitter -//
        public abstract Char KeyValueSplitter { get; }

        //- @ItemSplitter -//
        public abstract Char ItemSplitter { get; }

        //+
        //- @Load -//
        /// <summary>
        /// Loads the specified query string data.
        /// </summary>
        /// <param name="base64Data">The base64 data.</param>
        public virtual void Load(String data)
        {
            if (!String.IsNullOrEmpty(data))
            {
                String[] itemArray = data.Split(this.ItemSplitter);
                //+
                foreach (String item in itemArray)
                {
                    String[] keyValueArray = item.Split(this.KeyValueSplitter);
                    if (keyValueArray.Length == 2)
                    {
                        String key = keyValueArray[0].Replace(this.ScopeSplitter, "::");
                        this.Add(key, DecodeValue(keyValueArray[1]));
                    }
                }
            }
        }

        //- @Save -//
        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public virtual String Save()
        {
            StringBuilder data = new StringBuilder();
            //+
            Boolean first = true;
            List<String> keyList = this.GetKeyList();
            foreach (String key in keyList)
            {
                if (!first)
                {
                    data.Append(this.ItemSplitter);
                }
                first = false;
                String storableKey = key.Replace("::", this.ScopeSplitter);
                data.Append(storableKey + this.KeyValueSplitter + EncodeValue(this[key]));
            }
            //+
            return data.ToString();
        }

        //- #DecodeValue -//
        protected virtual String DecodeValue(String data)
        {
            return data;
        }

        //- #EncodeValue -//
        protected virtual String EncodeValue(String data)
        {
            return data;
        }
    }
}