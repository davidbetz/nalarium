#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

//+
namespace Nalarium.Web.Mvc
{
    public class Paragraph : WrappingControl
    {
        protected Paragraph()
        {
        }

        public static Paragraph Create()
        {
            return new Paragraph().ContainerType(HtmlElement.Paragraph) as Paragraph;
        }
    }
}