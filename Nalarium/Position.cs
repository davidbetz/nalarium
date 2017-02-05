#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

//+
namespace Nalarium
{
    /// <summary>
    ///     Represents a position.  May be used forward (first, second, third) or backward (ultima, penultima, antepenultima).
    /// </summary>
    public enum Position
    {
        /// <summary>
        ///     The first position
        /// </summary>
        First = 1,

        /// <summary>
        ///     The second position
        /// </summary>
        Second = 2,

        /// <summary>
        ///     The third position
        /// </summary>
        Third = 3,

        /// <summary>
        ///     The last position
        /// </summary>
        Ultima = 4,

        /// <summary>
        ///     The position before the ultima
        /// </summary>
        Penultima = 5,

        /// <summary>
        ///     The position before the penultima
        /// </summary>
        Antepenultima = 6
    }
}