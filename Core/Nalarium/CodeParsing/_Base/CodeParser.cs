#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
//+
namespace Nalarium.CodeParsing
{
    /// <summary>
    /// Presents a code parser.
    /// </summary>
    public abstract class CodeParser
    {
        //- @Id -//
        /// <summary>
        /// Gets the id.
        /// </summary>
        /// <value>The id.</value>
        public abstract String Id { get; }

        //- @Parse
        /// <summary>
        /// Parses the code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public abstract String ParseCode(String code);
    }
}