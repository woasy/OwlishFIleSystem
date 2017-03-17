using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlishFileSystem.Components
{
    public static class OwlishDelegater
    {
        public static Task<TTaskResult> InvokeIfHasTarget<TParam, TTaskResult>(this IEnumerable<IOwlishDelegater<TParam, TTaskResult>> delegaters, TParam param, IObserver<OwlishProgress> progressObserver, System.Threading.CancellationToken ct)
        {
            var target = delegaters.FirstOrDefault(d => d.IsTargetTypes(param));
            if (target == null)
            {
                throw new UnsupportedTypeOfOwlishFileSystemDelegateException();
            }
            else
            {
                return target.InvokeAsync(param, progressObserver, ct);
            }
        }

        public static Task InvokeIfHasTarget<TParam>(this IEnumerable<OwlishActionGenDelegater<TParam>> delegaters, TParam param, IObserver<OwlishProgress> progressObserver, System.Threading.CancellationToken ct)
        {
            return delegaters.InvokeIfHasTarget(new Tuple<TParam>(param), progressObserver, ct);
        }

        public static Task InvokeIfHasTarget<TParam1, TParam2>(this IEnumerable<OwlishActionGenDelegater<TParam1, TParam2>> delegaters, TParam1 param1, TParam2 param2, IObserver<OwlishProgress> progressObserver, System.Threading.CancellationToken ct)
        {
            return delegaters.InvokeIfHasTarget(new Tuple<TParam1, TParam2>(param1, param2), progressObserver, ct);
        }

        public static Task<TResult> InvokeIfHasTarget<TParam, TResult>(this IEnumerable<OwlishFuncGenDelegater<TParam, TResult>> delegaters, TParam param, IObserver<OwlishProgress> progressObserver, System.Threading.CancellationToken ct)
        {
            return delegaters.InvokeIfHasTarget(new Tuple<TParam>(param), progressObserver, ct);
        }

        public static Task<TResult> InvokeIfHasTarget<TParam1, TParam2, TResult>(this IEnumerable<OwlishFuncGenDelegater<TParam1, TParam2, TResult>> delegaters, TParam1 param1, TParam2 param2, IObserver<OwlishProgress> progressObserver, System.Threading.CancellationToken ct)
        {
            return delegaters.InvokeIfHasTarget(new Tuple<TParam1, TParam2>(param1, param2), progressObserver, ct);
        }
    }
}
