using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlishFileSystem.SystemIO
{
    public sealed class FileSystemHost : IOwlishFileSystemHost
    {
        private FileSystemHost()
        {

        }

        private static FileSystemHost _instance;
        public static FileSystemHost Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FileSystemHost();
                }
                return _instance;
            }
        }
    }
}
