using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OwlishFileSystem.SystemIO
{
    public class Path : IOwlishPath
    {
        public Path(IOwlishFileSystemHost host, string path)
        {
            AsString = path;
            Host = host;
        }
        
        private string AsString { get; set; }
        public IOwlishFileSystemHost Host { get; private set; }

        public override string ToString()
        {
            return AsString;
        }

        //public Path CreateCombinedPath(params string[] pathes)
        //{
        //    return new Path(Host, System.IO.Path.Combine(Enumerable.Concat<string>(new string[] { this.ToString() }, pathes).ToArray()));
        //}
    }
}
