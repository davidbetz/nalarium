#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
//+
namespace Nalarium.Data
{
    /// <summary>
    /// Represents a map that allows loading and saving of its data as query string-like data (i.e. A=B&C=D&E=F)
    /// </summary>
    public class QueryStringStorableMap : SeriesStorableMap
    {
        //- @ScopeSplitter -//
        public override String ScopeSplitter
        {
            get
            {
                return "::";
            }
        }

        //- @KeyValueSplitter -//
        public override Char KeyValueSplitter
        {
            get
            {
                return '=';
            }
        }

        //- @ItemSplitter -//
        public override Char ItemSplitter
        {
            get
            {
                return '&';
            }
        }

        //+
        //- #DecodeValue -//
        protected override String DecodeValue(String data)
        {
            if (!String.IsNullOrEmpty(data))
            {
                data = data.Replace("&", "&#38;");
                data = data.Replace("::", "&#58;&#58;");
                return data.Replace("=", "&#61;");
            }
            //+
            return String.Empty;
        }

        //- #EncodeValue -//
        protected override String EncodeValue(String data)
        {
            if (!String.IsNullOrEmpty(data))
            {
                data = data.Replace("&#38;", "&");
                data = data.Replace("&#58;&#58;", "::");
                return data.Replace("&#61;", "=");
            }
            //+
            return String.Empty;
        }
    }
}