using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OwlishFileSystem.SystemIO
{
    public class File : FileSystemObject, IOwlishFile
    {
        public File(string p)
            :base(p)
        {
        }

        public long GetSize()
        {
            throw new NotImplementedException();
        }

        protected override string ConvertPathToName(string v)
        {
            return System.IO.Path.GetFileName(v);
        }
    }
}
