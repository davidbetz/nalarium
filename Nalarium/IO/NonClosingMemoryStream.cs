#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System.IO;

namespace Nalarium.IO
{
    /// <summary>
    /// Represents a memory stream that stays open.
    /// </summary>
    public class NonClosingMemoryStream : MemoryStream
    {
        //- @Close -//
        /// <summary>
        /// Closes the current stream and releases any resources associated with the current stream.
        /// </summary>
        public override void Close()
        {
            Position = 0;
        }
    }
}