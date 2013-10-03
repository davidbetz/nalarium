#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;

namespace Nalarium.Activation
{
    public abstract class ObjectFactory : IFactory
    {
        //- @CreateObject -//
        /// <summary>
        /// Creates an object based on the specified text.
        /// </summary>
        /// <param name="text">The text used to create the object.</param>
        /// <returns>The created object.</returns>
        public abstract Object CreateObject(String text);
    }
}