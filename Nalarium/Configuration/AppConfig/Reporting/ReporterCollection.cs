#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System.Configuration;

namespace Nalarium.Configuration.AppConfig.Reporting
{
    public class ReporterCollection : CommentableCollection<ReporterElement>
    {
        //- #GetElementKey -//
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ReporterElement) element).Name;
        }
    }
}