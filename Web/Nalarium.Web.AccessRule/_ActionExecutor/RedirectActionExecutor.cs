#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
//+
namespace Nalarium.Web.AccessRule
{
    public class RedirectActionExecutor : ActionExecutor
    {
        //- @Process -//
        public override void Execute()
        {
            if (Value.StartsWith("http://") || Value.StartsWith("https://"))
            {
                Http.Response.Redirect(Value);
            }
        }
    }
}