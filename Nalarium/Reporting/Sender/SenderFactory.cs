#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

namespace Nalarium.Reporting.Sender
{
    public abstract class SenderFactory : Factory
    {
        //- @Create -//
        /// <summary>
        ///     Creates a specified sender factory from the aliased name
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public abstract Sender Create(string name);
    }
}