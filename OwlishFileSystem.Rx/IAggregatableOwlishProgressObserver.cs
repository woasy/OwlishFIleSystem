using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlishFileSystem.Rx
{
    interface IAggregatableOwlishProgressObserver : IObserver<OwlishProgress>
    {
    }
}
