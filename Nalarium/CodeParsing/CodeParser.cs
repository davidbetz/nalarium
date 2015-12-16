#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

namespace Nalarium.CodeParsing
{
    /// <summary>
    ///     Presents a code parser.
    /// </summary>
    public abstract class CodeParser
    {
        //- @Id -//
        /// <summary>
        ///     Gets the id.
        /// </summary>
        /// <value>The id.</value>
        public abstract string Id { get; }

        //- @Parse
        /// <summary>
        ///     Parses the code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public abstract string ParseCode(string code);
    }
}