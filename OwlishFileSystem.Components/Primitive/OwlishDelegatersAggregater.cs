using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlishFileSystem.Components.Primitive
{
    class OwlishDelegatersAggregater : IReadOnlyDictionary<IOwlishDelegatersKey, IOwlishDelegaters>, IList<IAggregatableOwlishDelegaters>
    {
    }
}
