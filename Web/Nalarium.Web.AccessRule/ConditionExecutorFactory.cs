#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
namespace Nalarium.Web.AccessRule
{
    internal static class ConditionExecutorFactory
    {
        //+
        //- $GetValue -//
        private static void ParseNameAndValue(String text, out String name, out String value)
        {
            if (String.IsNullOrEmpty(text))
            {
                name = String.Empty;
                value = String.Empty;
            }
            if (!text.StartsWith("{") || !text.StartsWith("}"))
            {
                name = String.Empty;
                value = String.Empty;
            }
            Int32 spaceIndex = text.IndexOf(" ");
            if (spaceIndex == -1)
            {
                name = text.Substring(1, text.Length - 2);
                value = String.Empty;
            }
            else
            {
                name = text.Substring(1, spaceIndex - 1);
                value = text.Substring(spaceIndex + 1, text.Length - spaceIndex - 2);
            }
        }

        //- @Create -//
        internal static ConditionExecutor Create(String usage, String text)
        {
            //+ prase
            String name;
            String value;
            ParseNameAndValue(text, out name, out value);
            name = name.ToLower();
            //+ select
            ConditionExecutor executor = null;
            switch (name)
            {
                case "host":
                    executor = new HostConditionExecutor();
                    break;

                case "range":
                    executor = new RangeConditionExecutor();
                    break;

                case "useragnet":
                    executor = new UserAgentConditionExecutor();
                    break;

                case "httpreferer":
                case "httpreferrer":
                    executor = new HttpReferrerConditionExecutor();
                    break;

                case "subdomain":
                    executor = new SubdomainConditionExecutor();
                    break;

                case "maskarea":
                    executor = new MaskAreaConditionExecutor();
                    break;
            }
            //+ init
            if (executor != null)
            {
                executor.Usage = usage;
                executor.Name = name;
                executor.Value = value;
            }
            //+
            return executor;
        }
    }
}