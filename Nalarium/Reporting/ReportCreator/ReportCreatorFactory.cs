#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

namespace Nalarium.Reporting.ReportCreator
{
    public abstract class ReportCreatorFactory : Factory
    {
        //- @Create -//
        /// <summary>
        ///     Creates a specified report creator from the aliased name
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public abstract ReportCreator Create(string name);
    }
}