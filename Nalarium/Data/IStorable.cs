#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;

namespace Nalarium.Data
{
    /// <summary>
    /// Represents an entity that has Load and Save (string) functionality.
    /// </summary>
    public interface IStorable
    {
        //- @Load -//
        /// <summary>
        /// Loads the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        void Load(String data);

        //- @Save -//
        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        String Save();
    }
}