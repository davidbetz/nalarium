#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

namespace Nalarium.Data
{
    /// <summary>
    ///     Represents a map with inherent scopes.
    /// </summary>
    public class ScopedMap : Map
    {
        //- @SetScopedEntry -//
        /// <summary>
        ///     Sets the scoped entry.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void SetScopedEntry(string scope, string key, string value)
        {
            Add(scope + "::" + key, value);
        }

        //- @GetScopedEntry -//
        /// <summary>
        ///     Gets the scoped entry.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public string GetScopedEntry(string scope, string key)
        {
            return Get(scope + "::" + key) ?? string.Empty;
        }
    }
}