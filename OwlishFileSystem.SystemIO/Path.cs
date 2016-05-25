using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OwlishFileSystem.SystemIO
{
    public class Path : IOwlishPath
    {
        public Path(string path)
        {
            AsString = path;
        }

        private string AsString { get; set; }

        public override string ToString()
        {
            return AsString;
        }

        public Path CreateCombinedPath(params string[] pathes)
        {
            return new Path(System.IO.Path.Combine(Enumerable.Concat<string>(new string[] { this.ToString() }, pathes).ToArray()));
        }

        IOwlishPath IOwlishPath.CreateCombinedPath(params string[] p)
        {
            return CreateCombinedPath(p);
        }
    }
}
