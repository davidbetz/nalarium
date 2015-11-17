using System;

namespace Nalarium
{
    /// <summary>
    /// Used to add a reference for documentation.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public class CommentAttribute : Attribute
    {
        /// <summary>
        /// Comment text
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Create with text
        /// </summary>
        /// <param name="text">text</param>
        public CommentAttribute(string text)
        {
            Text = Text;
        }
    }
}