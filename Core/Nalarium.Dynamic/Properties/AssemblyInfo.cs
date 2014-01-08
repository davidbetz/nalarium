using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

[assembly: CLSCompliant(true)]
[assembly: AssemblyTitle("Jampad Technology, Inc. 2007-2014 Pro 3.3 - Core Module (Dynamic)")]
[assembly: AssemblyDescription(".NET Development Foundation")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Jampad Technology, Inc.")]
[assembly: AssemblyProduct("Jampad Technology, Inc. 2007-2014 Pro 3.3 - Core Module (Dynamic)")]
[assembly: AssemblyCopyright("Copyright © Jampad Technology, Inc. 2007-2014")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
//+

[assembly: ComVisible(false)]
//+

[assembly: Guid("94a98536-c18d-49af-9920-74fd848e3367")]
//+

[assembly: AssemblyVersion("3.3.1.0")]
[assembly: AssemblyFileVersion("3.3.1.0")]
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