#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Collections.Generic;

namespace Nalarium.Web.AccessRule
{
    internal class Rule
    {
        //- @Action -//
        public Action Action { get; set; }

        //- @Condition -//
        public Condition Condition { get; set; }

        //- @WhenList -//
        public List<Condition> WhenList { get; set; }

        //- @Check -//
        public bool Check()
        {
            Boolean execute = false;
            if (!Collection.IsNullOrEmpty(WhenList))
            {
                Int32 requiredCount = WhenList.Count;
                WhenList.ForEach(p =>
                                 {
                                     if (p.Check())
                                     {
                                         requiredCount--;
                                         if (requiredCount == 0)
                                         {
                                             execute = true;
                                         }
                                     }
                                 });
            }
            else if (Condition != null)
            {
                if (Condition.Check())
                {
                    execute = true;
                }
            }
            else
            {
                execute = true;
            }
            //+
            return execute;
        }
    }
}