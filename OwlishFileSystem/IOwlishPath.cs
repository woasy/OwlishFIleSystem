﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OwlishFileSystem
{
    public interface IOwlishPath
    {
        IOwlishFileSystemHost Host { get; }
    }
}
