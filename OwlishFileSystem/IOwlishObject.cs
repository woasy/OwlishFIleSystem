using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OwlishFileSystem
{
    public interface IOwlishObject
    {
        event EventHandler<PropertyUpdatedEventArgs> PropertyUpdated;
        
        IOwlishPath Path { get; }
        string Name { get; }

    }
}
