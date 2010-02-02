#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
//+
namespace Nalarium.Web.Mvc
{
    public class Break : Nalarium.Web.Mvc.Control
    {
        protected Break()
        {
        }

        public static Break Create()
        {
            return new Break();
        }

        public override string Render()
        {
            return "<br />";
        }
    }
}