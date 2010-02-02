#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
//+
namespace Nalarium
{
    public static class PairSplitter
    {
        //- @Split -//
        public static Map Split(String[] pairArray)
        {
            if (pairArray == null)
            {
                return new Map();
            }
            Map map = new Map();
            foreach (String item in pairArray)
            {
                String trimmed = item.Trim();
                if (trimmed.Contains("="))
                {
                    String first;
                    String second;
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
        public static void Split(String text, out String first, out String second)
        {
            if (String.IsNullOrEmpty(text))
            {
                first = String.Empty;
                second = String.Empty;
                return;
            }
            text = text.Trim();
            if (!text.Contains("="))
            {
                first = String.Empty;
                second = String.Empty;
                return;
            }
            String name = String.Empty;
            String value = String.Empty;
            Int32 index = text.IndexOf('=');
            first = text.Substring(0, index);
            second = text.Substring(index + 1, text.Length - index - 1);
        }
    }
}