#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

namespace Nalarium.Reporting.ReportCreator.Formatter
{
    public abstract class FormatterFactory : Factory
    {
        //- @Create -//
        /// <summary>
        ///     Creates a formatter based on the specified alias
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public abstract Formatter Create(string name);
    }
}