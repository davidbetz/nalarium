#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright � Jampad Technology, Inc. 2007-2010
#endregion
using System;
//+
namespace Nalarium.Activation
{
    public class TypeData
    {
        //- @Name -//
        /// <summary>
        /// Name of the type.
        /// </summary>
        public String Name { get; set; }

        //- @AssemblyName -//
        /// <summary>
        /// Strongly typed name of the assembly.
        /// </summary>
        public System.Reflection.AssemblyName AssemblyName { get; set; }

        //+
        //- @ToString -//
        public override String ToString()
        {
            if (AssemblyName != null)
            {
                return Name + ", " + AssemblyName.ToString();
            }
            //+
            return String.Empty;
        }
    }
}