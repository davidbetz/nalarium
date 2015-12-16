#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System;

namespace Nalarium.Activation
{
    public abstract class TypeFactory : IFactory
    {
        //- @CreateObject -//
        /// <summary>
        ///     Creates an Type object based on the specified text.
        /// </summary>
        /// <param name="text">The text used to create the object.</param>
        /// <returns>The created Type object.</returns>
        public abstract Type CreateType(string text);
    }
}