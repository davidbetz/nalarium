#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

//+
namespace Nalarium.Web.Mvc
{
    /// <summary>
    /// Represents an HTML span element
    /// </summary>
    public class Span : WrappingControl
    {
        protected Span()
        {
        }

        public static Span Create()
        {
            return new Span().ContainerType(HtmlElement.Span) as Span;
        }
    }
}