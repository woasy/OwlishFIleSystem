using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlishFileSystem.SystemIO
{
    public class FileSystemObject : IOwlishObject
    {
        public event EventHandler<PropertyUpdatedEventArgs> PropertyUpdated;

        public FileSystemObject(string path)
            : this(new Path(path))
        {
        }
        public FileSystemObject(Path path)
        {
            this.FileSystemHost = FileSystemHost.Instance;
            this.Path = path;
            this.Name = System.IO.Path.GetDirectoryName(path.ToString());
        }

        public FileSystemHost FileSystemHost { get; private set; }
        public Path Path { get; private set; }
        public string Name { get; private set; }

        IOwlishFileSystemHost IOwlishObject.FileSystemHost { get { return this.FileSystemHost; } }
        IOwlishPath IOwlishObject.Path { get { return this.Path; } }
    }
}
