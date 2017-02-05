#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System;
using System.Text;
using Nalarium.Globalization;
using Nalarium.Properties;

namespace Nalarium.Data
{
    /// <summary>
    ///     Represents a map that allows loading and saving of its data as base64 data.
    /// </summary>
    public class Base64StorableMap : SeriesStorableMap
    {
        //- @ScopeSplitter -//
        public Base64StorableMap()
        {
        }

        public Base64StorableMap(string base64Data)
        {
            Load(base64Data);
        }

        public override string ScopeSplitter
        {
            get { return "\x02"; }
        }

        //- @KeyValueSplitter -//
        public override char KeyValueSplitter
        {
            get { return '\x04'; }
        }

        //- @ItemSplitter -//
        public override char ItemSplitter
        {
            get { return '\x03'; }
        }

        //+
        //- @Ctor -//

        //+
        //- @Load -//
        /// <summary>
        ///     Loads the specified base64 data.
        /// </summary>
        /// <param name="base64Data">The base64 data.</param>
        public override void Load(string base64Data)
        {
            var data = string.Empty;
            try
            {
                var buffer = Convert.FromBase64String(base64Data);
                data = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
            }
            catch
            {
                throw new FormatException(ResourceAccessor.GetString("Base64_InvalidData", AssemblyInfo.AssemblyName, Resource.ResourceManager));
            }
            //+
            base.Load(data);
        }

        //- @Save -//
        /// <summary>
        ///     Saves this instance.
        /// </summary>
        /// <returns></returns>
        public override string Save()
        {
            var data = base.Save();
            //+
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(data));
        }
    }
}