#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System.Reflection;

namespace Nalarium.Activation
{
    public class TypeData
    {
        //- @Name -//
        /// <summary>
        ///     Name of the type.
        /// </summary>
        public string Name { get; set; }

        //- @AssemblyName -//
        /// <summary>
        ///     Strongly typed name of the assembly.
        /// </summary>
        public AssemblyName AssemblyName { get; set; }

        //+
        //- @ToString -//
        public override string ToString()
        {
            if (AssemblyName != null)
            {
                return Name + ", " + AssemblyName;
            }
            //+
            return string.Empty;
        }
    }
}