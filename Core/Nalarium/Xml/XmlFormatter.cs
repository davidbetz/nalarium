#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2008-2013

#endregion

using System;
using System.IO;
using System.Text;
using System.Xml;

namespace Nalarium.Xml
{
    public static class XmlFormatter
    {
        //- @Format -//
        /// <summary>
        /// Formats the given XML.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static String Format(String input)
        {
            var stream = new MemoryStream();
            var doc = new XmlDocument();
            doc.LoadXml(input);
            var writer = new XmlTextWriter(stream, null);
            writer.Formatting = Formatting.Indented;
            writer.IndentChar = ' ';
            writer.Indentation = 2;
            doc.Save(writer);
            //+
            Byte[] buffer = stream.ToArray();
            String output = Encoding.UTF8.GetString(buffer);
            Int32 lastAngle = output.LastIndexOf(">");
            output = output.Substring(0, lastAngle + 1);
            //+
            return output;
        }

        //- @TryFormat -//
        /// <summary>
        /// Tries to format the given XML.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="output">The output.</param>
        /// <returns></returns>
        public static Boolean TryFormat(String input, out String output)
        {
            Boolean result = false;
            try
            {
                output = Format(input);
            }
            catch
            {
                output = String.Empty;
            }
            //+
            return result;
        }
    }
}