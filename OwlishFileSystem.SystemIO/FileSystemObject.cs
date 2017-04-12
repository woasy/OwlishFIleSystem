using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlishFileSystem.SystemIO
{
    public abstract class FileSystemObject : IOwlishObject
    {
        public event EventHandler<PropertyUpdatedEventArgs> PropertyUpdated;

        public FileSystemObject(Path path)
        {
            this.Path = path;
            this.Name = ConvertPathToName(path.ToString());
        }

        abstract protected string ConvertPathToName(string v);

        public Path Path { get; protected set; }
        public string Name { get; protected set; }

        IOwlishPath IOwlishObject.Path { get { return this.Path; } }
    }
}
