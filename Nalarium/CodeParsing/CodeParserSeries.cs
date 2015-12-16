#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Nalarium.Globalization;
using Nalarium.Properties;

namespace Nalarium.CodeParsing
{
    /// <summary>
    ///     Holds a series of code parsers to be processed in order.
    /// </summary>
    public class CodeParserSeries
    {
        //- @CodeParserId -//
        /// <summary>
        ///     Initializes a new instance of the <see cref="CodeParserSeries" /> class.
        /// </summary>
        public CodeParserSeries()
        {
            CodeParserList = new List<CodeParser>();
        }

        /// <summary>
        ///     Gets or sets the code parser id.
        /// </summary>
        /// <value>The code parser id.</value>
        public string CodeParserId { get; set; }

        //- @CodeParserQueue -//
        /// <summary>
        ///     Gets or sets the code parser list.
        /// </summary>
        /// <value>The code parser list.</value>
        public List<CodeParser> CodeParserList { get; set; }

        //+
        //- @Ctor -//

        //+
        //- @Add -//
        /// <summary>
        ///     Adds the specified code parser.
        /// </summary>
        /// <param name="codeParser">The code parser.</param>
        public void Add(CodeParser codeParser)
        {
            CodeParserList.Add(codeParser);
        }

        //- #ParseCode -//
        /// <summary>
        ///     Parses the code.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        public string ParseCode(string content)
        {
            if (string.IsNullOrEmpty(CodeParserId))
            {
                throw new ArgumentNullException(ResourceAccessor.GetString("CodeParser_CodeParserIdRequired", AssemblyInfo.AssemblyName, Resource.ResourceManager));
            }
            var matchPattern = @"{" + CodeParserId + @"{(?<type>[_\-a-z0-9]+){(?<code>[ |;,_\-a-z0-9]+)}}}";
            var matchCollection = Regex.Matches(content, matchPattern, RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
            foreach (Match match in matchCollection)
            {
                var typeGroup = match.Groups["type"];
                var codeGroup = match.Groups["code"];
                //+
                var codeParser = FindCodeParser(typeGroup.Value);
                var parsed = codeParser?.ParseCode(codeGroup.Value);
                if (parsed != null)
                {
                    var replacementPattern = string.Format(CultureInfo.CurrentCulture, "{{{0}{{{1}{{{2}}}}}}}", CodeParserId, typeGroup.Value, codeGroup.Value);
                    replacementPattern = replacementPattern.Replace("|", "\\|");
                    content = Regex.Replace(content, replacementPattern, parsed, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
                }
            }
            //+
            return content;
        }

        //- $FindCodeParser -//
        private CodeParser FindCodeParser(string codeParserId)
        {
            return CodeParserList.FirstOrDefault(p => p.Id == codeParserId);
        }
    }
}