#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
//+
namespace Nalarium.Web.Mvc
{
    /// <summary>
    /// Represents an HTML div element
    /// </summary>
    public class Div : Nalarium.Web.Mvc.WrappingControl
    {
        protected Div()
        {
        }

        public static Div Create()
        {
            return new Div().ContainerType(Nalarium.Web.HtmlElement.Div) as Div;
        }
    }
}