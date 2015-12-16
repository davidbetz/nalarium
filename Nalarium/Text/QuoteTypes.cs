#region Copyright

//+ Copyright © David Betz 2008-2013

#endregion

using System;

namespace Nalarium.Text
{
    /// <summary>
    ///     Type of quotes.
    /// </summary>
    [Flags]
    public enum QuoteTypes
    {
        Single = 0x01,
        Double = 0x02,
        Both = 0x04
    }
}