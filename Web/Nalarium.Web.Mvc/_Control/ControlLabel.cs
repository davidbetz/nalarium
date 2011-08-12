#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
namespace Nalarium.Web.Mvc
{
    public class Label : Control
    {
        protected Label()
        {
        }

        public static Label Create()
        {
            return new Label();
        }

        //- @ForId -//
        private String _forId;
        public String ForId()
        {
            return _forId;
        }
        public Label ForId(String value)
        {
            _forId = value;
            //+
            return this;
        }

        //- @Suffix -//
        private String _suffix;
        public String Suffix()
        {
            return _suffix;
        }
        public Label Suffix(String value)
        {
            _suffix = value;
            //+
            return this;
        }

        //- @Text -//
        private String _text;
        public String Text()
        {
            return _text;
        }
        public Label Text(String value)
        {
            _text = value;
            //+
            return this;
        }

        //+
        //- @Render -//
        public override System.Web.HtmlString Render()
        {
            String forId = ForId();
            if (String.IsNullOrEmpty(forId))
            {
                return new System.Web.HtmlString(String.Empty);
            }
            System.Text.StringBuilder builder = new System.Text.StringBuilder("<label for=\"" + forId + "\">");
            builder.Append(Text() + Suffix());
            builder.Append("</label>");
            //+
            return new System.Web.HtmlString(builder.ToString());
        }
    }
}
