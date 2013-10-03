#region Copyright

//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2008-2013

#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace Nalarium.Xml
{
    public static class XPathProcessor
    {
        public static XmlNode GetNode(String xml, String xpath)
        {
            var doc = new XmlDocument();
            doc.Load(new StringReader(xml));
            return GetNode(doc, xpath);
        }
        public static XmlNode GetNode(XmlDocument doc, String xpath)
        {
            if (doc != null && doc.DocumentElement != null)
            {
                XmlNode node = doc.DocumentElement.SelectSingleNode(xpath);
                return node;
            }
            //+
            return null;
        }

        public static List<XmlNode> GetAllNodeData(String xml, String xpath)
        {
            var doc = new XmlDocument();
            doc.Load(new StringReader(xml));
            return GetAllNodeData(doc, xpath);
        }
        public static List<XmlNode> GetAllNodeData(XmlDocument doc, String xpath)
        {
            var list = new List<XmlNode>();
            if (doc != null && doc.DocumentElement != null)
            {
                var data = doc.DocumentElement.SelectNodes(xpath);
                if (data == null)
                {
                    return list;
                }
                list.AddRange(data.Cast<object>().Cast<XmlNode>());
                return list;
            }
            //+
            return null;
        }

        public static String GetString(String xml, String xpath)
        {
            var doc = new XmlDocument();
            doc.Load(new StringReader(xml));
            return GetString(doc, xpath);
        }
        public static String GetString(XmlDocument doc, String xpath)
        {
            if (doc != null && doc.DocumentElement != null)
            {
                XmlNode node = doc.DocumentElement.SelectSingleNode(xpath);
                if (node != null)
                {
                    return node.InnerXml;
                }
            }
            //+
            return String.Empty;
        }
    }
}