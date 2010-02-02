#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Nalarium.Globalization;
//+
namespace Nalarium.CodeParsing
{
    /// <summary>
    /// Holds a series of code parsers to be processed in order.
    /// </summary>
    public class CodeParserSeries
    {
        //- @CodeParserId -//
        /// <summary>
        /// Gets or sets the code parser id.
        /// </summary>
        /// <value>The code parser id.</value>
        public String CodeParserId { get; set; }

        //- @CodeParserQueue -//
        /// <summary>
        /// Gets or sets the code parser list.
        /// </summary>
        /// <value>The code parser list.</value>
        public List<CodeParser> CodeParserList { get; set; }

        //+
        //- @Ctor -//
        /// <summary>
        /// Initializes a new instance of the <see cref="CodeParserSeries"/> class.
        /// </summary>
        public CodeParserSeries()
        {
            CodeParserList = new List<CodeParser>();
        }

        //+
        //- @Add -//
        /// <summary>
        /// Adds the specified code parser.
        /// </summary>
        /// <param name="codeParser">The code parser.</param>
        public void Add(CodeParser codeParser)
        {
            this.CodeParserList.Add(codeParser);
        }

        //- #ParseCode -//
        /// <summary>
        /// Parses the code.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        public String ParseCode(String content)
        {
            if (String.IsNullOrEmpty(this.CodeParserId))
            {
                throw new ArgumentNullException(ResourceAccessor.GetString("CodeParser_CodeParserIdRequired", AssemblyInfo.AssemblyName, Resource.ResourceManager));
            }
            String matchPattern = @"{" + this.CodeParserId + @"{(?<type>[_\-a-z0-9]+){(?<code>[ |;,_\-a-z0-9]+)}}}";
            MatchCollection matchCollection = Regex.Matches(content, matchPattern, RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
            foreach (Match match in matchCollection)
            {
                Group typeGroup = match.Groups["type"];
                Group codeGroup = match.Groups["code"];
                //+
                CodeParser codeParser = FindCodeParser(typeGroup.Value);
                if (codeParser != null)
                {
                    String parsed = codeParser.ParseCode(codeGroup.Value);
                    if (parsed != null)
                    {
                        String replacementPattern = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{{{0}{{{1}{{{2}}}}}}}", this.CodeParserId, typeGroup.Value, codeGroup.Value);
                        replacementPattern = replacementPattern.Replace("|", "\\|");
                        content = Regex.Replace(content, replacementPattern, parsed, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
                    }
                }
            }
            //+
            return content;
        }

        //- $FindCodeParser -//
        private CodeParser FindCodeParser(String codeParserId)
        {
            return this.CodeParserList.FirstOrDefault(p => p.Id == codeParserId);
        }
    }
}