#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
//+
namespace Nalarium.Activation
{
    public abstract class PropertyDataBase
    {
        //- @Name -//
        /// <summary>
        /// Property name.
        /// </summary>
        public String Name { get; set; }

        //- @GetType -//
        /// <summary>
        /// Property type.
        /// </summary>
        public abstract Type Type { get; set; }
    }
}