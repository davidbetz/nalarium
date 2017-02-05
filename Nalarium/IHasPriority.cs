#region Copyright

//+ Copyright © David Betz 2007-2017

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