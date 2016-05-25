using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OwlishFileSystem
{
    public interface IOwlishPath
    {
        IOwlishPath CreateCombinedPath(params string[] p);
    }
}
