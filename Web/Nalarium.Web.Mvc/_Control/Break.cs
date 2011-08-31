#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

//+
using System.Web;

namespace Nalarium.Web.Mvc
{
    public class Break : Control
    {
        protected Break()
        {
        }

        public static Break Create()
        {
            return new Break();
        }

        public override HtmlString Render()
        {
            return new HtmlString("<br />");
        }
    }
}