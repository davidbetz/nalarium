#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
//+
namespace Nalarium.Activation
{
    public abstract class TypeFactory : IFactory
    {
        //- @CreateObject -//
        /// <summary>
        /// Creates an Type object based on the specified text.
        /// </summary>
        /// <param name="text">The text used to create the object.</param>
        /// <returns>The created Type object.</returns>
        public abstract Type CreateType(String text);
    }
}