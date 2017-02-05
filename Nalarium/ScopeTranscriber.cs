#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System;

namespace Nalarium
{
    public static class ScopeTranscriber
    {
        private static readonly string[] ScopeSymbolAsArray =
        {
            "::"
        };

        //+
        //- @Construct -//
        /// <summary>
        ///     Constructs a scoped name based on a scope and a name.
        /// </summary>
        /// <param name="scope">The scope to use.</param>
        /// <param name="name">The name to scope.</param>
        /// <returns>The full name of the format Scope::Name.</returns>
        public static string Construct(string scope, string name)
        {
            return scope + "::" + name;
        }

        /// <summary>
        ///     Constructs a culture aware scoped name based on a scope, a two digit culture code, and a name.
        /// </summary>
        /// <param name="scope">The scope to use.</param>
        /// <param name="culture">The two letter culture used to create extended scope.</param>
        /// <param name="name">The name to scope.</param>
        /// <returns>The full name of the format Scope::Name.</returns>
        public static string Construct(string scope, string culture, string name)
        {
            return scope + "::" + culture + "::" + name;
        }

        //- @Deconstruct -//
        /// <summary>
        ///     Returns the parts of a full name.
        /// </summary>
        /// <param name="fullname">The scope to deconstruct.</param>
        /// <returns>
        ///     A string array holding the scope and name.  If the scope has culture code, the culture code will also be
        ///     returned in the order of scope, culture, and name.
        /// </returns>
        public static string[] Deconstruct(string fullname)
        {
            if (string.IsNullOrEmpty(fullname))
            {
                return null;
            }
            if (!fullname.Contains("::"))
            {
                return null;
            }
            //+
            return fullname.Split(ScopeSymbolAsArray, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}