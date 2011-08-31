using System;
using System.Collections.Generic;
using System.Reflection;

namespace Nalarium
{
    public static class PairAndSeriesBuilder
    {
        public static String CreateSeries(params string[] pair)
        {
            if (pair == null || pair.Length == 0)
            {
                return String.Empty;
            }
            return "{ " + String.Join(", ", pair) + " }";
        }

        public static String CreatePair(object p1, object p2)
        {
            return p1 + "=" + p2;
        }

        public static String CreateSeries(Object obj)
        {
            return CreateSeries(obj, false);
        }

        public static String CreateSeries(Object obj, Boolean useScope)
        {
            if (obj == null)
            {
                return String.Empty;
            }
            var pairList = new List<string>();
            Type t = obj.GetType();
            FieldInfo[] fieldArray = t.GetFields();
            foreach (FieldInfo field in fieldArray)
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