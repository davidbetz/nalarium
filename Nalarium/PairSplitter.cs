#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

namespace Nalarium
{
    public static class PairSplitter
    {
        //- @Split -//
        public static Map Split(string[] pairArray)
        {
            if (pairArray == null)
            {
                return new Map();
            }
            var map = new Map();
            foreach (var item in pairArray)
            {
                var trimmed = item.Trim();
                if (trimmed.Contains("="))
                {
                    string first;
                    string second;
                    Split(trimmed, out first, out second);
                    //+
                    map.Add(first, second);
                }
                else
                {
                    map.Add(trimmed, null);
                }
            }
            //+
            return map;
        }

        public static void Split(string text, out string first, out string second)
        {
            if (string.IsNullOrEmpty(text))
            {
                first = string.Empty;
                second = string.Empty;
                return;
            }
            text = text.Trim();
            if (!text.Contains("="))
            {
                first = string.Empty;
                second = string.Empty;
                return;
            }
            var name = string.Empty;
            var value = string.Empty;
            var index = text.IndexOf('=');
            first = text.Substring(0, index);
            second = text.Substring(index + 1, text.Length - index - 1);
        }
    }
}