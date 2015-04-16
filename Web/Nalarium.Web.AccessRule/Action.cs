#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;

namespace Nalarium.Web.AccessRule
{
    internal class Action
    {
        public ActionExecutor _executor;

        //+
        //- @Value -//

        //+
        //- $Ctor -//
        private Action()
        {
        }

        public String Value { get; set; }

        //+
        //- @Check -//
        public static Action Create(String value)
        {
            ActionExecutor executor = ActionExecutorFactory.Create(value);
            if (executor == null)
            {
                return null;
            }
            //+
            return new Action
                   {
                       Value = value,
                       _executor = executor
                   };
        }

        public void Execute()
        {
            _executor.Execute();
        }
    }
}