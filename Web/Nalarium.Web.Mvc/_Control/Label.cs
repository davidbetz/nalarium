#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Text;
using System.Web;

namespace Nalarium.Web.Mvc
{
    public class Label : Control
    {
        private String _forId;
        private String _suffix;
        private String _text;

        protected Label()
        {
        }

        public static Label Create()
        {
            return new Label();
        }

        //- @ForId -//

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
        public override HtmlString Render()
        {
            String forId = ForId();
            if (String.IsNullOrEmpty(forId))
            {
                return new HtmlString(String.Empty);
            }
            var builder = new StringBuilder("<label for=\"" + forId + "\">");
            builder.Append(Text() + Suffix());
            builder.Append("</label>");
            //+
            return new HtmlString(builder.ToString());
        }
    }
}