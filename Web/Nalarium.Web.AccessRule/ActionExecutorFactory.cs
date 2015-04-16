#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;

namespace Nalarium.Web.AccessRule
{
    internal static class ActionExecutorFactory
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
        internal static ActionExecutor Create(String text)
        {
            if (text.Equals("permit", StringComparison.CurrentCultureIgnoreCase))
            {
                return new PermitExecutor();
            }
            else if (text.Equals("block", StringComparison.CurrentCultureIgnoreCase))
            {
                return new BlockActionExecutor();
            }
            //+ parse
            String name;
            String value;
            ParseNameAndValue(text, out name, out value);
            name = name.ToLower();
            //+ select
            ActionExecutor executor = null;
            switch (name)
            {
                case "write":
                    executor = new WriteActionExecutor();
                    break;

                case "redirect":
                    executor = new RedirectActionExecutor();
                    break;
            }
            //+ init
            if (executor != null)
            {
                executor.Name = name;
                executor.Value = value;
            }
            //+
            return executor;
        }
    }
}