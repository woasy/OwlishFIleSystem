using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OwlishFileSystem.SystemIO
{
    public class File : FileSystemObject
    {
        public File(string path)
            : base(new Path(path))
        {
        }
        public File(Path path)
            : base(path)
        {
        }

        public long GetSize()
        {
            throw new NotImplementedException();
        }
    }
}
