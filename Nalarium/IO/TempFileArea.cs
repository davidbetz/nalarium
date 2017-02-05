#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System;
using System.IO;
using System.Linq;

namespace Nalarium.IO
{
    public class TempFileArea : IDisposable
    {
        private readonly bool _createdFolder;

        public TempFileArea()
        {
            var baseFolder = System.IO.Path.GetTempPath();
            Folder = System.IO.Path.Combine(baseFolder, GuidCreator.GetNewGuid());
            if (!Directory.Exists(Folder))
            {
                Directory.CreateDirectory(Folder);
                _createdFolder = true;
            }
        }

        public string Folder { get; }

        public void Dispose()
        {
            if (_createdFolder && !Directory.GetFiles(Folder, "*.*", SearchOption.AllDirectories).Any())
            {
                Directory.Delete(Folder);
            }
        }
    }
}