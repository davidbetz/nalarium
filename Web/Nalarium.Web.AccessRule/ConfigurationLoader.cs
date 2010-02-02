#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
using System.Collections.Generic;
//+
namespace Nalarium.Web.AccessRule
{
    public static class ConfigurationLoader
    {
        internal static Boolean _isLoaded = false;

        //+
        //- @Load -//
        public static void Load()
        {
            lock (RuleMap._Lock)
            {
                if (_isLoaded)
                {
                    return;
                }
                RuleMap.Current = new RuleMap();
                Configuration.AccessRuleSection section = Configuration.AccessRuleSection.GetConfigSection();
                foreach (Nalarium.Web.AccessRule.Configuration.RuleElement ruleElement in section.Rules)
                {
                    RuleGroup group = RuleMap.Current[ruleElement.Group];
                    if (group == null)
                    {
                        group = new RuleGroup();
                        RuleMap.Current[ruleElement.Group] = group;
                    }
                    Action action = Action.Create(ruleElement.Action);
                    if (action == null)
                    {
                        continue;
                    }
                    Rule rule = new Rule
                    {
                        Action = action
                    };
                    if (ruleElement.Composite.Count > 0)
                    {
                        rule.WhenList = new List<Condition>();
                        foreach (Nalarium.Web.AccessRule.Configuration.MatchElement when in ruleElement.Composite)
                        {
                            Condition condition = Condition.Create(when.Usage, when.Value);
                            if (condition == null)
                            {
                                continue;
                            }
                            rule.WhenList.Add(condition);
                        }
                    }
                    else if (!String.IsNullOrEmpty(ruleElement.Condition))
                    {
                        Condition condition = Condition.Create(String.Empty, ruleElement.Condition);
                        if (condition == null)
                        {
                            continue;
                        }
                        rule.Condition = condition;
                    }
                    //else
                    //{
                    //    if (!ruleElement.Action.Equals("permit", StringComparison.InvariantCultureIgnoreCase) && !ruleElement.Action.Equals("deny", StringComparison.InvariantCultureIgnoreCase))
                    //    {
                    //        throw new System.Configuration.ConfigurationErrorsException();
                    //    }
                    //}
                    group.Add(rule);
                }
                foreach (RuleGroup ruleGroup in RuleMap.Current.Values)
                {
                    ruleGroup.Add(new Rule
                    {
                        Action = Action.Create("Block")
                    });
                }
                //+
                _isLoaded = true;
            }
        }
    }
}