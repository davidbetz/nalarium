#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
namespace Nalarium.Web.AccessRule
{
    internal class Condition
    {
        public ConditionExecutor _executor = null;

        //+
        //- @Usage -//
        public String Usage { get; set; }

        //- @Value -//
        public String Value { get; set; }

        //+
        //- $Ctor -//
        private Condition()
        {
        }

        //+
        //- @Create -//
        public static Condition Create(String usage, String value)
        {
            ConditionExecutor executor = ConditionExecutorFactory.Create(usage, value);
            if (executor == null)
            {
                return null;
            }
            //+
            return new Condition
            {
                Usage = usage,
                Value = value,
                _executor = executor
            };
        }

        //+
        //- @Check -//
        public Boolean Check()
        {
            return _executor.Process();
        }
    }
}