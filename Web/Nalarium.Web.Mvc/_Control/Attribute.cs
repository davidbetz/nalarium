#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
namespace Nalarium.Web.Mvc
{
    public class Attribute : Control
    {
        private Attribute()
        {
        }

        public static Attribute Create()
        {
            return new Attribute();
        }

        //- @Name -//
        private String _name;
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
        private String _value;
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

        public override System.Web.HtmlString Render()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append(" " + Name() + "=\"" + Value() + "\"");
            //+
            return new System.Web.HtmlString(builder.ToString());
        }
    }
}