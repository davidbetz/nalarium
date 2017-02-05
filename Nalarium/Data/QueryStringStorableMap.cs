#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

namespace Nalarium.Data
{
    /// <summary>
    ///     Represents a map that allows loading and saving of its data as query string-like data (i.e. A=B&C=D&E=F)
    /// </summary>
    public class QueryStringStorableMap : SeriesStorableMap
    {
        //- @ScopeSplitter -//
        public override string ScopeSplitter
        {
            get { return "::"; }
        }

        //- @KeyValueSplitter -//
        public override char KeyValueSplitter
        {
            get { return '='; }
        }

        //- @ItemSplitter -//
        public override char ItemSplitter
        {
            get { return '&'; }
        }

        //+
        //- #DecodeValue -//
        protected override string DecodeValue(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                data = data.Replace("&", "&#38;");
                data = data.Replace("::", "&#58;&#58;");
                return data.Replace("=", "&#61;");
            }
            //+
            return string.Empty;
        }

        //- #EncodeValue -//
        protected override string EncodeValue(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                data = data.Replace("&#38;", "&");
                data = data.Replace("&#58;&#58;", "::");
                return data.Replace("&#61;", "=");
            }
            //+
            return string.Empty;
        }
    }
}