using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OwlishFileSystem.SystemIO
{
    public class Directory : FileSystemObject, IOwlishDirectory
    {
        public Directory(Path path)
            : base(path)
        {
        }

        public IEnumerable<FileSystemObject> EnumerateSubObjects()
        {
            foreach (var i in EnumerateSubDirectories())
            {
                yield return i;
            }
            foreach (var i in EnumerateSubFiles())
            {
                yield return i;
            }
        }

        protected override string ConvertPathToName(string v)
        {
            return System.IO.Path.GetDirectoryName(v);
        }
    }
}
