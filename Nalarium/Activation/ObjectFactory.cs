#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

namespace Nalarium.Activation
{
    public abstract class ObjectFactory : IFactory
    {
        //- @CreateObject -//
        /// <summary>
        ///     Creates an object based on the specified text.
        /// </summary>
        /// <param name="text">The text used to create the object.</param>
        /// <returns>The created object.</returns>
        public abstract object CreateObject(string text);
    }
}