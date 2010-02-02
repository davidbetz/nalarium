#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
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