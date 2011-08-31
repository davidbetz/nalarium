using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

[assembly: CLSCompliant(true)]
[assembly: AssemblyTitle("Nalarium Pro 3.0 - Core Module")]
[assembly: AssemblyDescription(".NET Development Foundation")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Jampad Technology, Inc.")]
[assembly: AssemblyProduct("Nalarium Pro 3.0 - Core Module")]
[assembly: AssemblyCopyright("Copyright © Jampad Technology, Inc. 2007-2010")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
//+

[assembly: ComVisible(false)]
//+

[assembly: Guid("6E249E3E-95D3-416C-B9DD-544B08255E43")]
//+

[assembly: AssemblyVersion("3.0.0.0")]
[assembly: AssemblyFileVersion("3.0.0.0")]
//+

namespace Nalarium
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