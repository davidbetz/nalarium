using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

[assembly: CLSCompliant(true)]
[assembly: AssemblyTitle("Nalarium Pro 2.0 - Web (Processing.Mvc)")]
[assembly: AssemblyDescription(".NET Development Platform")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Jampad Technology, Inc.")]
[assembly: AssemblyProduct("Nalarium Pro 2.0 - Web (Processing.Mvc)")]
[assembly: AssemblyCopyright("Copyright © Jampad Technology, Inc. 2008-2010")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
//+

[assembly: ComVisible(false)]
//+

[assembly: Guid("D129BD5D-2196-404E-ABB9-AFAE56E4D68C")]
//+

[assembly: AssemblyVersion("3.0.0.0")]
[assembly: AssemblyFileVersion("3.0.0.0")]
//+

namespace Nalarium.Web.Processing.Mvc
{
    [NotDocumented]
    public class AssemblyInfo
    {
        internal static Assembly _Assembly = typeof(AssemblyInfo).Assembly;

        //+
        public static String AssemblyName = _Assembly.FullName;
        public static Byte[] PublicKey = _Assembly.GetName().GetPublicKey();
        public static String PublicKeyString = Encoding.UTF8.GetString(PublicKey).ToLower();
    }
}