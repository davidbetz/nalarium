using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

[assembly: CLSCompliant(true)]
[assembly: AssemblyTitle("Nalarium")]
[assembly: AssemblyDescription(".NET Development Foundation")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("David Betz")]
[assembly: AssemblyProduct("Nalarium")]
[assembly: AssemblyCopyright("Copyright © David Betz 2007-2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
//+

[assembly: ComVisible(false)]
//+

[assembly: Guid("6E249E3E-95D3-416C-B9DD-544B08255E43")]
//+

[assembly: AssemblyVersion("3.5.11.0")]
[assembly: AssemblyFileVersion("3.5.11.0")]
//+

namespace Nalarium.Properties
{
    [NotDocumented]
    public class AssemblyInfo
    {
        internal static Assembly _Assembly = typeof (AssemblyInfo).Assembly;

        //+
        public static string AssemblyName = _Assembly.FullName;
        public static byte[] PublicKey = _Assembly.GetName().GetPublicKey();
        public static string PublicKeyString = Encoding.UTF8.GetString(PublicKey).ToLower();
    }
}