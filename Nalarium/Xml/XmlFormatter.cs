#region Copyright

//+ Copyright © David Betz 2008-2013

#endregion

using System.IO;
using System.Text;
using System.Xml;

namespace Nalarium.Xml
{
    public static class XmlFormatter
    {
        //- @Format -//
        /// <summary>
        ///     Formats the given XML.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static string Format(string input)
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
            var buffer = stream.ToArray();
            var output = Encoding.UTF8.GetString(buffer);
            var lastAngle = output.LastIndexOf(">");
            output = output.Substring(0, lastAngle + 1);
            //+
            return output;
        }

        //- @TryFormat -//
        /// <summary>
        ///     Tries to format the given XML.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="output">The output.</param>
        /// <returns></returns>
        public static bool TryFormat(string input, out string output)
        {
            var result = false;
            try
            {
                output = Format(input);
            }
            catch
            {
                output = string.Empty;
            }
            //+
            return result;
        }
    }
}