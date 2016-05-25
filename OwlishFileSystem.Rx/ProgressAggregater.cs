using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OwlishFileSystem;
using System.Reactive.Subjects;

namespace OwlishFileSystem.Rx
{
    class ProgressAggregater : IObservable<OwlishProgress>
    {
        private Subject<OwlishProgress> _publisher;
        private Subject<long> _maxObserver;
        private Subject<OwlishProgress> _curObserver;
        private long _max;

        public IObserver<long> MaxProgressesObserver { get { return _maxObserver; } }
        public IObserver<OwlishProgress> CurrentProgressObserver { get { return _curObserver; } }

        public ProgressAggregater()
        {
            _publisher = new Subject<OwlishProgress>();
            _maxObserver = new Subject<long>();
            _maxObserver.Subscribe(Max_OnNext);
            _curObserver = new Subject<OwlishProgress>();
            _curObserver.Subscribe(Cur_OnNext, Cur_OnError, Cur_OnCompleted);
        }

        private void Cur_OnCompleted()
        {
            _publisher.OnCompleted();
        }

        private void Cur_OnError(Exception obj)
        {
            _publisher.OnError(obj);
        }

        private void Cur_OnNext(OwlishProgress obj)
        {

        }

        private void Max_OnNext(long obj)
        {

        }

        private void Publish()
        {
            string message;
            string file;
            long max;
            long cur;

        }

        public IDisposable Subscribe(IObserver<OwlishProgress> observer)
        {
            return this._publisher.Subscribe(observer);
        }
    }
}
