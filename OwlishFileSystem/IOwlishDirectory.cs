using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlishFileSystem
{
    public interface IOwlishDirectory : IOwlishObject
    {
        IEnumerable<IOwlishObject> EnumerateSubObjects();
        IEnumerable<IOwlishDirectory> EnumerateSubDirectories();
        IEnumerable<IOwlishFile> EnumerateSubFiles();
    }
}
