﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OwlishFileSystem.Components
{
    public interface IOwlishDelegater<TParam, TResult>
    {
        bool IsTargetTypes(TParam param);
        Task<TResult> InvokeAsync(TParam param, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
    }

    public class OwlishFuncGenDelegaterBase<TParam, TResult> : IOwlishDelegater<TParam, TResult>
    {
        public delegate bool IsTargetDelegate(TParam param);
        public delegate Task<TResult> InvokeDelegate(TParam param, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        private IsTargetDelegate _isTarget;
        private InvokeDelegate _invoke;

        public OwlishFuncGenDelegaterBase(IsTargetDelegate isTarget, InvokeDelegate invoker)
        {
            _isTarget = isTarget;
            _invoke = invoker;
        }

        public bool IsTargetTypes(TParam param)
        {
            return _isTarget(param);
        }

        public Task<TResult> InvokeAsync(TParam param, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            return _invoke(param, progressObserver, ct);
        }
    }

    public class OwlishActionGenDelegaterBase<TParam> : OwlishFuncGenDelegaterBase<TParam, object>
    {
        new public delegate Task InvokeDelegate(TParam param, IObserver<OwlishProgress> progressObserver, CancellationToken ct);

        public OwlishActionGenDelegaterBase(IsTargetDelegate isTarget, InvokeDelegate invoker)
            :base(isTarget, ConvertFuncInvoker(invoker))
        {
        }

        private static OwlishFuncGenDelegaterBase<TParam, object>.InvokeDelegate ConvertFuncInvoker(InvokeDelegate invoker)
        {
            return async (p, o, ct) => { await invoker(p, o, ct); return null; };
        }
    }

    internal class OwlishGenStaticComponents
    {
        internal static bool IsTargetImpl<T>(Tuple<T> param)
        {
            return param.Item1 is T;
        }

        internal static bool IsTargetImpl<T1, T2>(Tuple<T1, T2> param)
        {
            return param.Item1 is T1 && param.Item2 is T2;
        }
    }

    public class OwlishActionGenDelegater<TParam> : OwlishActionGenDelegaterBase<Tuple<TParam>>
    {
        public OwlishActionGenDelegater(InvokeDelegate invoker)
            : base(OwlishGenStaticComponents.IsTargetImpl<TParam>, invoker)
        {
        }
    }

    public class OwlishActionGenDelegater<TParam1, TParam2> : OwlishActionGenDelegaterBase<Tuple<TParam1, TParam2>>
    {
        public OwlishActionGenDelegater(InvokeDelegate invoker)
            : base(OwlishGenStaticComponents.IsTargetImpl<TParam1, TParam2>, invoker)
        {
        }
    }

    public class OwlishFuncGenDelegater<TParam, TResult> : OwlishFuncGenDelegaterBase<Tuple<TParam>, TResult>
    {
        public OwlishFuncGenDelegater(InvokeDelegate invoker)
            : base(OwlishGenStaticComponents.IsTargetImpl<TParam>, invoker)
        {
        }
    }

    public class OwlishFuncGenDelegater<TParam1, TParam2, TResult> : OwlishFuncGenDelegaterBase<Tuple<TParam1, TParam2>, TResult>
    {
        public OwlishFuncGenDelegater(InvokeDelegate invoker)
            : base(OwlishGenStaticComponents.IsTargetImpl<TParam1, TParam2>, invoker)
        {
        }

    }

    public class OwlishCopyFileAsyncGenDelegater<TFile, TPath> : OwlishActionGenDelegater<TFile, TPath>
        where TFile : IOwlishFile
        where TPath : IOwlishPath
    {
        public OwlishCopyFileAsyncGenDelegater(InvokeDelegate invoker)
            : base(invoker)
        {
        }
    }

    public class OwlishCopyDirectoryAsyncGenDelegater<TDirectory, TPath> : OwlishActionGenDelegater<IOwlishDirectory, IOwlishPath>
        where TDirectory : IOwlishDirectory
        where TPath : IOwlishPath
    {
        public OwlishCopyDirectoryAsyncGenDelegater(InvokeDelegate invoker)
            :base(invoker)
        {
        }
    }

    

}
