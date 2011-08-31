#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Text;
using System.Web;

namespace Nalarium.Web.Mvc
{
    public class Attribute : Control
    {
        private String _name;
        private String _value;

        private Attribute()
        {
        }

        public static Attribute Create()
        {
            return new Attribute();
        }

        //- @Name -//

        public String Name()
        {
            return _name;
        }

        public Attribute Name(String value)
        {
            _name = value;
            //+
            return this;
        }

        //- @Value -//

        public String Value()
        {
            return _value;
        }

        public Attribute Value(String value)
        {
            _value = value;
            //+
            return this;
        }

        public override HtmlString Render()
        {
            var builder = new StringBuilder();
            builder.Append(" " + Name() + "=\"" + Value() + "\"");
            //+
            return new HtmlString(builder.ToString());
        }
    }
}