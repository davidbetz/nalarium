using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

[assembly: CLSCompliant(true)]
[assembly: AssemblyTitle("Nalarium Core Module")]
[assembly: AssemblyDescription(".NET Development Foundation")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Jampad Technology, Inc.")]
[assembly: AssemblyProduct("Nalarium Core Module")]
[assembly: AssemblyCopyright("Copyright © Jampad Technology, Inc. 2007-2015")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
//+

[assembly: ComVisible(false)]
//+

[assembly: Guid("6E249E3E-95D3-416C-B9DD-544B08255E43")]
//+

[assembly: AssemblyVersion("3.3.4.0")]
[assembly: AssemblyFileVersion("3.3.4.0")]
//+

namespace Nalarium.Properties
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