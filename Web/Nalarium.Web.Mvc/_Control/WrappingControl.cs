#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Nalarium.Web.Mvc
{
    /// <summary>
    /// Represents a control container
    /// </summary>
    public abstract class WrappingControl : Control
    {
        private HtmlElement _containerType = HtmlElement.None;
        private String _content;
        private Control _control;

        protected WrappingControl()
        {
            AttributeList = new List<Attribute>();
        }

        public List<Attribute> AttributeList { get; set; }

        //+
        //- @ContainerType -//
        public HtmlElement ContainerType()
        {
            return _containerType;
        }

        public WrappingControl ContainerType(HtmlElement type)
        {
            _containerType = type;
            //+
            return this;
        }

        //- @TagName -//
        public String TagName()
        {
            switch (_containerType)
            {
                case HtmlElement.Div:
                    return "div";
                case HtmlElement.Paragraph:
                    return "p";
                case HtmlElement.Span:
                    return "span";
                default:
                    return String.Empty;
            }
        }

        //- @Content -//

        public String Content()
        {
            return _content;
        }

        public Control ContentAsControl()
        {
            return _control;
        }

        public WrappingControl Content(String value)
        {
            _content = value;
            //+
            return this;
        }

        public WrappingControl Content(Control value)
        {
            _control = value;
            //+
            return this;
        }

        //- @DefaultContent -//
        public WrappingControl Attribute(Attribute value)
        {
            if (value != null)
            {
                AttributeList.Add(value);
            }
            //+
            return this;
        }

        //+
        //- @Render -//
        public override HtmlString Render()
        {
            var builder = new StringBuilder();
            if (!String.IsNullOrEmpty(TagName()))
            {
                builder.Append("<" + TagName());
                foreach (Attribute item in AttributeList)
                {
                    builder.Append(item.Render());
                }
                builder.Append(">");
            }
            if (ContentAsControl() != null)
            {
                builder.Append(ContentAsControl());
            }
            else
            {
                builder.Append(Content());
            }
            if (!String.IsNullOrEmpty(TagName()))
            {
                builder.Append("</" + TagName() + ">");
            }
            //+
            return new HtmlString(builder.ToString());
        }
    }
}