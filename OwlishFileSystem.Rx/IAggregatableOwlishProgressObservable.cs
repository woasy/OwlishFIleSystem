using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlishFileSystem.Rx
{
    class AggregatableOwlishProgressObservable : IObservable<OwlishProgress>
    {
        public IDisposable Subscribe(IAggregatableOwlishProgressObserver observer)
        {
            return ((IObservable<OwlishProgress>)this).Subscribe(observer);
        }

        IDisposable IObservable<OwlishProgress>.Subscribe(IObserver<OwlishProgress> observer)
        {
            throw new NotImplementedException();
        }
    }
}
