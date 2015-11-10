#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2008-2013

#endregion

using System;

namespace Nalarium.Text
{
    /// <summary>
    /// Type of quotes.
    /// </summary>
    [Flags]
    public enum QuoteTypes
    {
        Single = 0x01,
        Double = 0x02,
        Both = 0x04,
    }
}