using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OwlishFileSystem.SystemIO
{
    public class Directory : FileSystemObject, IOwlishDirectory
    {
        public Directory(string path)
            : base(new Path(path))
        {
        }
        public Directory(Path path)
            : base(path)
        {
        }

        public IEnumerable<Directory> EnumerateSubDirectories()
        {
            return System.IO.Directory.EnumerateDirectories(this.Path.ToString())
                .Select(p => new Directory(p));
        }

        public IEnumerable<File> EnumerateSubFiles()
        {
            return System.IO.Directory.EnumerateDirectories(this.Path.ToString())
                .Select(p => new File(p));
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

        IEnumerable<IOwlishDirectory> IOwlishDirectory.EnumerateSubDirectories()
        {
            return EnumerateSubDirectories();
        }

        IEnumerable<IOwlishFile> IOwlishDirectory.EnumerateSubFiles()
        {
            return EnumerateSubFiles();
        }

        IEnumerable<IOwlishObject> IOwlishDirectory.EnumerateSubObjects()
        {
            return EnumerateSubObjects();
        }
    }
}
