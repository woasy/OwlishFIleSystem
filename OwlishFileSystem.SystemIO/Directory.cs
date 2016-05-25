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

        public IEnumerable<IOwlishObject> EnumerateSubObjects()
        {
            return Enumerable.Concat<IOwlishObject>(this.EnumerateSubDirectories(), this.EnumerateSubFiles());
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
    }
}
