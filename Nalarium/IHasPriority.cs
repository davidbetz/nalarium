#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

namespace Nalarium
{
    /// <summary>
    ///     Declares that a type has a priority
    /// </summary>
    public interface IHasPriority
    {
        //- Priority -//
        int Priority { get; set; }
    }
}