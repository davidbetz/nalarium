#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

//+
namespace Nalarium.Web.AccessRule
{
    public class WriteActionExecutor : ActionExecutor
    {
        //- @Execute -//
        public override void Execute()
        {
            Nalarium.Web.Http.Response.Write(Value);
            Nalarium.Web.Http.Response.End();
        }
    }
}