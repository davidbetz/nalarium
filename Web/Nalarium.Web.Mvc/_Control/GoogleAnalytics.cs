#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
namespace Nalarium.Web.Mvc
{
    /// <summary>
    /// Adds Google Analytics to the page.
    /// </summary>
    public class GoogleAnalytics : Control
    {
        protected GoogleAnalytics(String trackingCode)
        {
            TrackingCode(trackingCode);
        }

        public static GoogleAnalytics Create(String trackingCode)
        {
            return new GoogleAnalytics(trackingCode);
        }

        //- @TrackingCode -//
        private String _trackingCode;
        public String TrackingCode()
        {
            return _trackingCode;
        }
        public GoogleAnalytics TrackingCode(String value)
        {
            _trackingCode = value;
            //+
            return this;
        }

        //- @Path -//
        private String _path;
        public String Path()
        {
            return _path;
        }
        public GoogleAnalytics Path(String value)
        {
            _path = value;
            //+
            return this;
        }

        public override System.Web.HtmlString Render()
        {
            if (String.IsNullOrEmpty(TrackingCode()))
            {
                return new System.Web.HtmlString(String.Empty);
            }
            String path = Path();
            if (!String.IsNullOrEmpty(path))
            {
                path = "'" + path.ToLower() + "'";
            }
            String output = @"<script type=""text/javascript"">
var gaJsHost = ((""https:"" == document.location.protocol) ? ""https://ssl."" : ""http://www."");
document.write(unescape(""%3Cscript src='"" + gaJsHost + ""google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E""));
</script>
<script type=""text/javascript"">
try{
var pageTracker = _gat._getTracker(""" + TrackingCode() + @""");
pageTracker._trackPageview(" + path + @");
} catch(err) {}</script>";
            //+
            return new System.Web.HtmlString(output);
        }
    }
}