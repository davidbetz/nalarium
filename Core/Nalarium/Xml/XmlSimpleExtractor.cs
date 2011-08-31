#region Copyright

//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using Nalarium.Globalization;

namespace Nalarium.Xml
{
    public static class XmlSimpleExtractor
    {
        //- @ExtractBranch -//
        /// <summary>
        /// Extracts the branch.
        /// </summary>
        /// <param name="mailRoot">The mail root.</param>
        /// <param name="branchName">Name of the branch.</param>
        /// <param name="required">if set to <c>true</c> [required].</param>
        /// <returns></returns>
        public static List<String> ExtractBranch(XmlNode mailRoot, String branchName, Boolean required)
        {
            var list = new List<String>();
            XmlNode result = mailRoot.SelectSingleNode(branchName);
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
                    throw new XmlException(String.Format(CultureInfo.CurrentCulture, ResourceAccessor.GetString("General_MissingElement", AssemblyInfo.AssemblyName, Resource.ResourceManager), branchName));
                }
            }
            //+
            return list;
        }

        //- @ExtractText -//
        /// <summary>
        /// Extracts the text.
        /// </summary>
        /// <param name="mailRoot">The mail root.</param>
        /// <param name="nodeName">Name of the node.</param>
        /// <returns></returns>
        public static String ExtractText(XmlNode mailRoot, String nodeName)
        {
            XmlNode result = mailRoot.SelectSingleNode(nodeName);
            if (result != null)
            {
                return result.InnerText;
            }
            else
            {
                throw new XmlException(String.Format(CultureInfo.CurrentCulture, ResourceAccessor.GetString("General_MissingElement", AssemblyInfo.AssemblyName, Resource.ResourceManager), nodeName));
            }
        }
    }
}