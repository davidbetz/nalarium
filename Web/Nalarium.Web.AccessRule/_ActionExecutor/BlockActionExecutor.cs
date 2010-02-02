#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
//+
namespace Nalarium.Web.AccessRule
{
    public class BlockActionExecutor : ActionExecutor
    {
        //- @Execute -//
        public override void Execute()
        {
            System.Web.HttpResponse response = Http.Response;
            response.SuppressContent = true;
            response.End();
        }
    }
}