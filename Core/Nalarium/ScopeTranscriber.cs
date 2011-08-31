#region Copyright

//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010

#endregion

using System;

namespace Nalarium
{
    public static class ScopeTranscriber
    {
        private static readonly String[] ScopeSymbolAsArray = new[]
                                                              {
                                                                  "::"
                                                              };

        //+
        //- @Construct -//
        /// <summary>
        /// Constructs a scoped name based on a scope and a name.
        /// </summary>
        /// <param name="scope">The scope to use.</param>
        /// <param name="name">The name to scope.</param>
        /// <returns>The full name of the format Scope::Name.</returns>
        public static String Construct(String scope, String name)
        {
            return scope + "::" + name;
        }

        /// <summary>
        /// Constructs a culture aware scoped name based on a scope, a two digit culture code, and a name.
        /// </summary>
        /// <param name="scope">The scope to use.</param>
        /// <param name="culture">The two letter culture used to create extended scope.</param>
        /// <param name="name">The name to scope.</param>
        /// <returns>The full name of the format Scope::Name.</returns>
        public static String Construct(String scope, String culture, String name)
        {
            return scope + "::" + culture + "::" + name;
        }

        //- @Deconstruct -//
        /// <summary>
        /// Returns the parts of a full name.
        /// </summary>
        /// <param name="scope">The scope to deconstruct.</param>
        /// <returns>A string array holding the scope and name.  If the scope has culture code, the culture code will also be returned in the order of scope, culture, and name.</returns>
        public static String[] Deconstruct(String fullname)
        {
            if (String.IsNullOrEmpty(fullname))
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