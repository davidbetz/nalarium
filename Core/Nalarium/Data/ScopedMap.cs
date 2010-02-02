#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
//+
namespace Nalarium.Data
{
    /// <summary>
    /// Represents a map with inherent scopes.
    /// </summary>
    public class ScopedMap : Nalarium.Map
    {
        //- @SetScopedEntry -//
        /// <summary>
        /// Sets the scoped entry.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void SetScopedEntry(String scope, String key, String value)
        {
            this.Add(scope + "::" + key, value);
        }

        //- @GetScopedEntry -//
        /// <summary>
        /// Gets the scoped entry.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public String GetScopedEntry(String scope, String key)
        {
            return PeekSafely(scope + "::" + key) ?? String.Empty;
        }
    }
}