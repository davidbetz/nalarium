#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System;

namespace Nalarium
{
    /// <summary>
    ///     Used to signify that a particular type was pulled from a third part project or peice of research.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, Inherited = false)]
    public class CitationAttribute : Attribute
    {
        private readonly string _source;

        /// <summary>
        ///     Create with source
        /// </summary>
        /// <param name="source"></param>
        public CitationAttribute(string source)
        {
            _source = source;
            //+
            DateCulture = "en-US";
            License = "Custom";
        }

        //+
        //- @Copyright -//
        /// <summary>
        ///     Represents the copyright of the referenced entity.
        /// </summary>
        public string Copyright { get; set; }

        //- @DateUpdated -//
        /// <summary>
        ///     Represents the date the local version was updated with the referenced entity.
        /// </summary>
        public string DateUpdated { get; set; }

        //- @DateUpdated -//
        /// <summary>
        ///     Represents the 2 (i.e. "en") or 5 (i.e. "en-US") character culture used to format the date (default = en-US)
        /// </summary>
        public string DateCulture { get; set; }

        //- @License -//
        /// <summary>
        ///     Represents the license associated with this file (e.g. BSD, MIT, LGPL, Public Domain; default = Custom). This
        ///     property is not legally binding.  It should only be used as a means of finding the general direction of where to
        ///     look for the legally binding license.
        /// </summary>
        public string License { get; set; }

        //- @Ctor -//

        //+
    }
}