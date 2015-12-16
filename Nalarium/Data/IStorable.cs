#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

namespace Nalarium.Data
{
    /// <summary>
    ///     Represents an entity that has Load and Save (string) functionality.
    /// </summary>
    public interface IStorable
    {
        //- @Load -//
        /// <summary>
        ///     Loads the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        void Load(string data);

        //- @Save -//
        /// <summary>
        ///     Saves this instance.
        /// </summary>
        /// <returns></returns>
        string Save();
    }
}