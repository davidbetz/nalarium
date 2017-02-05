#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System.Collections.Generic;

namespace Nalarium.CodeParsing
{
    public abstract class CodeParserTemplate
    {
        public abstract string Code { get; }

        public abstract string Template { get; }

        public CodeParserTemplate AddCode(string key, string value)
        {
            if (CodeData == null)
            {
                CodeData = new Dictionary<string, string>();
            }
            CodeData.Add(key, value);

            return this;
        }

        public void MergeMap(Map map)
        {
            if (CodeData == null)
            {
                return;
            }
            foreach (var key in CodeData.Keys)
            {
                map.Add(key, CodeData[key]);
            }
        }

        public Dictionary<string, string> CodeData { get; set; }

        public virtual Map Setup()
        {
            return new Map();
        }
    }
}