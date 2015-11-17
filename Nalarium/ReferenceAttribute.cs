using System;

namespace Nalarium
{
    /// <summary>
    /// Used to add a reference for documentation.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public class ReferenceAttribute : Attribute
    {
        /// <summary>
        /// Link to reference
        /// </summary>
        public Uri Reference { get; }

        /// <summary>
        /// Create with link uri
        /// </summary>
        /// <param name="reference">uri</param>
        public ReferenceAttribute(Uri reference)
        {
            Reference = reference;
        }

        /// <summary>
        /// Create with link text
        /// </summary>
        /// <param name="reference">text</param>
        public ReferenceAttribute(string reference)
        {
            Reference = new Uri(reference);
        }
    }
}