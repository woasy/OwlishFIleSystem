using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OwlishFileSystem.Components
{
    public abstract class OwlishDelegatedFileSystemHost : IOwlishFileSystemHost
    {
        public delegate Task CopyFileAsyncDelegate(IOwlishFile file, IOwlishPath newPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        public delegate Task CopyDirectoryAsyncDelegate(IOwlishDirectory directory, IOwlishPath newPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        public delegate Task MoveFileAsyncDelegate(IOwlishFile file, IOwlishPath newPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        public delegate Task MoveDirectoryAsyncDelegate(IOwlishDirectory directory, IOwlishPath newPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        public delegate Task RemoveFileAsyncDelegate(IOwlishFile file, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        public delegate Task RemoveDirectoryAsyncDelegate(IOwlishDirectory directory, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        public delegate Task<bool> GetIsFileExisitAsyncDelegate(IOwlishFile file, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        public delegate Task<bool> GetIsDirectoryExisitAsyncDelegate(IOwlishDirectory directory, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        public delegate Task<PathExistResult> GetIsPathExisitAsyncDelegate(IOwlishPath directoryPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        public delegate Task<System.IO.Stream> GetFileStreamToReadAsyncDelegate(IOwlishFile file, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        public delegate Task<System.IO.Stream> GetFileStreamToWriteAsyncDelegate(IOwlishFile file, IObserver<OwlishProgress> progressObserver, CancellationToken ct, bool append = false);
        public delegate Task<IOwlishFile> CreateFileAsyncDelegate(IOwlishPath path, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        public delegate Task<IOwlishDirectory> CreateDirecotryAsyncDelegate(IOwlishPath path, IObserver<OwlishProgress> progressObserver, CancellationToken ct);

        abstract public IEnumerable<OwlishCopyFileAsyncGenDelegater> CopyFileAsyncDelegaters { get; }
        abstract public IEnumerable<OwlishCopyDirectoryAsyncGenDelegater> CopyDirectoryAsyncDelegaters { get; }
        abstract public IEnumerable<IOwlishAsyncDelegater<Tuple<IOwlishFile, IOwlishPath>>> MoveFileAsyncDelegaters { get; }
        abstract public IEnumerable<IOwlishAsyncDelegater<Tuple<IOwlishDirectory, IOwlishPath>>> MoveDirectoryAsyncDelegaters { get; }
        abstract public IEnumerable<IOwlishAsyncDelegater<Tuple<IOwlishFile>>> RemoveFileAsyncDelegaters { get; }
        abstract public IEnumerable<IOwlishAsyncDelegater<Tuple<IOwlishDirectory>>> RemoveDirectoryAsyncDelegaters { get; }
        abstract public IEnumerable<IOwlishAsyncDelegater<OwlishFileDelegaterParam>> GetIsFileExistAsyncDelegaters { get; }
        abstract public IEnumerable<IOwlishAsyncDelegater<OwlishDirectoryDelegaterParam>> GetIsDirectoryExistAsyncDelegaters { get; }
        abstract public IEnumerable<IOwlishAsyncDelegater<OwlishPathDelegaterParam>> GetIsPathExistAsyncDelegaters { get; }
        
        private Task<TTaskResult> InvokeImpl<IDelegater, TParam, TTaskResult>(IEnumerable<IDelegater> delegaters, Func<IDelegater, Task<TTaskResult>> invoker, TParam param)
            where IDelegater : IOwlishDelegaterBase<TParam>
        {
            var target = delegaters.FirstOrDefault(d => d.IsTargetTypes(param));
            if (target == null)
            {
                throw new UnsupportedTypeOfOwlishFileSystemDelegateException();
            }
            else
            {
                return invoker(target);
            }
        }

        private Task<TTaskResult> InvokeIfHasTarget<TParam, TTaskResult>(IEnumerable<IOwlishDelegater<TParam, TTaskResult>> delegaters, TParam param, IObserver<OwlishProgress> progressObserver, System.Threading.CancellationToken ct)
        {
            return InvokeImpl(delegaters, d => d.InvokeAsync(param, progressObserver, ct), param);
        }

        private Task InvokeIfHasTarget<TParam>(IEnumerable<IOwlishAsyncDelegater<TParam>> delegaters, TParam param, IObserver<OwlishProgress> progressObserver, System.Threading.CancellationToken ct)
        {
            return InvokeImpl<IOwlishAsyncDelegater<TParam>, TParam, object>(delegaters, d => { d.InvokeAsync(param, progressObserver, ct); return null; }, param);
        }

        public Task CopyFileAsync(IOwlishFile file, IOwlishPath newPath, IObserver<OwlishProgress> progressObserver, System.Threading.CancellationToken ct)
        {
            return InvokeIfHasTarget(CopyFileAsyncDelegaters, new OwlishFileAndPathDelegaterParam() { File = file, Path = newPath }, progressObserver, ct);
        }

        public Task CopyDirectoryAsync(IOwlishDirectory directory, IOwlishPath newPath, IObserver<OwlishProgress> progressObserver, System.Threading.CancellationToken ct)
        {
            return InvokeIfHasTarget(CopyDirectoryAsyncDelegaters, new OwlishDirectoryAndPathDelegaterParam() { Directory = directory, Path = newPath }, progressObserver, ct);
        }

        public Task MoveFileAsync(IOwlishFile file, IOwlishPath newPath, IObserver<OwlishProgress> progressObserver, System.Threading.CancellationToken ct)
        {
            return InvokeIfHasTarget(MoveFileAsyncDelegaters, new OwlishMoveFileAsyncDelegateParam() { File = file, Path = newPath }, progressObserver, ct);
        }

        public Task MoveDirectoryAsync(IOwlishDirectory directory, IOwlishPath newPath, IObserver<OwlishProgress> progressObserver, System.Threading.CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFileAsync(IOwlishFile file, IObserver<OwlishProgress> progressObserver, System.Threading.CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task RemoveDirectoryAsync(IOwlishDirectory directory, IObserver<OwlishProgress> progressObserver, System.Threading.CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetIsFileExisitAsync(IOwlishFile file, IObserver<OwlishProgress> progressObserver, System.Threading.CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetIsDirectoryExisitAsync(IOwlishDirectory directory, IObserver<OwlishProgress> progressObserver, System.Threading.CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<PathExistResult> GetIsPathExisitAsync(IOwlishPath directoryPath, IObserver<OwlishProgress> progressObserver, System.Threading.CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<System.IO.Stream> GetFileStreamToReadAsync(IOwlishFile file, IObserver<OwlishProgress> progressObserver, System.Threading.CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<System.IO.Stream> GetFileStreamToWriteAsync(IOwlishFile file, IObserver<OwlishProgress> progressObserver, System.Threading.CancellationToken ct, bool append = false)
        {
            throw new NotImplementedException();
        }

        public Task<IOwlishFile> CreateFileAsync(IOwlishPath path, IObserver<OwlishProgress> progressObserver, System.Threading.CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<IOwlishDirectory> CreateDirecotryAsync(IOwlishPath path, IObserver<OwlishProgress> progressObserver, System.Threading.CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
