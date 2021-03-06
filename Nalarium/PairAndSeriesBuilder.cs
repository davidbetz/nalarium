#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System.Collections.Generic;

namespace Nalarium
{
    public static class PairAndSeriesBuilder
    {
        public static string CreateSeries(params string[] pair)
        {
            if (pair == null || pair.Length == 0)
            {
                return string.Empty;
            }
            return "{ " + string.Join(", ", pair) + " }";
        }

        public static string CreatePair(object p1, object p2)
        {
            return p1 + "=" + p2;
        }

        public static string CreateSeries(object obj)
        {
            return CreateSeries(obj, false);
        }

        public static string CreateSeries(object obj, bool useScope)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            var pairList = new List<string>();
            var t = obj.GetType();
            var fieldArray = t.GetFields();
            foreach (var field in fieldArray)
            {
                if (useScope)
                {
                    pairList.Add(CreatePair(ScopeTranscriber.Construct(t.Name, field.Name), field.GetValue(obj).ToString()));
                }
                else
                {
                    pairList.Add(CreatePair(field.Name, field.GetValue(obj)));
                }
            }
            return CreateSeries(pairList.ToArray());
        }
    }
}