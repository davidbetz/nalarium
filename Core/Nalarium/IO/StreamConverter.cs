#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using System.IO;

namespace Nalarium.IO
{
    public static class StreamConverter
    {
        //- @CreateStream -//
        /// <summary>
        /// Creates the stream.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static T CreateStream<T>(String text) where T : Stream, new()
        {
            var stream = new T();
            var writer = new BinaryWriter(stream);
            writer.Write(text);
            //+
            return stream;
        }

        /// <summary>
        /// Creates the stream.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static T CreateStream<T>(Byte[] data) where T : Stream, new()
        {
            var stream = new T();
            var writer = new BinaryWriter(stream);
            writer.Write(data);
            //+
            return stream;
        }

        //- @GetStreamByteArray -//
        /// <summary>
        /// Gets the stream byte array.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns></returns>
        public static Byte[] GetStreamByteArray(Stream stream)
        {
            if (stream == null)
            {
                return null;
            }
            stream.Seek(0, SeekOrigin.Begin);
            var r = new BinaryReader(stream);
            //+
            return r.ReadBytes((Int32)stream.Length);
        }

        //- @GetStreamText -//
        /// <summary>
        /// Gets the stream text.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns></returns>
        public static String GetStreamText(Stream stream)
        {
            if (stream == null)
            {
                return String.Empty;
            }
            stream.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(stream);
            //+
            return reader.ReadToEnd();
        }
    }
}