#region Copyright

//+ Copyright © David Betz 2008-2013

#endregion

using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using Nalarium.Globalization;
using Nalarium.Properties;

namespace Nalarium.Xml
{
    public static class XmlSimpleExtractor
    {
        //- @ExtractBranch -//
        /// <summary>
        ///     Extracts the branch.
        /// </summary>
        /// <param name="mailRoot">The mail root.</param>
        /// <param name="branchName">Name of the branch.</param>
        /// <param name="required">if set to <c>true</c> [required].</param>
        /// <returns></returns>
        public static List<string> ExtractBranch(XmlNode mailRoot, string branchName, bool required = false)
        {
            var list = new List<string>();
            var result = mailRoot.SelectSingleNode(branchName);
            if (result != null && result.HasChildNodes)
            {
                foreach (XmlNode node in result.ChildNodes)
                {
                    list.Add(node.InnerText);
                }
            }
            else
            {
                if (required)
                {
                    throw new XmlException(string.Format(CultureInfo.CurrentCulture, ResourceAccessor.GetString("General_MissingElement", AssemblyInfo.AssemblyName, Resource.ResourceManager), branchName));
                }
            }
            //+
            return list;
        }

        //- @ExtractText -//
        /// <summary>
        ///     Extracts the text.
        /// </summary>
        /// <param name="mailRoot">The mail root.</param>
        /// <param name="nodeName">Name of the node.</param>
        /// <returns></returns>
        public static string ExtractText(XmlNode mailRoot, string nodeName)
        {
            var result = mailRoot.SelectSingleNode(nodeName);
            if (result != null)
            {
                return result.InnerText;
            }
            throw new XmlException(string.Format(CultureInfo.CurrentCulture, ResourceAccessor.GetString("General_MissingElement", AssemblyInfo.AssemblyName, Resource.ResourceManager), nodeName));
        }
    }
}