#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
using System.Xml;
//+
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
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(input);
            XmlTextWriter writer = new XmlTextWriter(stream, null);
            writer.Formatting = Formatting.Indented;
            writer.IndentChar = ' ';
            writer.Indentation = 2;
            doc.Save(writer);
            //+
            Byte[] buffer = stream.ToArray();
            String output = System.Text.UTF8Encoding.UTF8.GetString(buffer);
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