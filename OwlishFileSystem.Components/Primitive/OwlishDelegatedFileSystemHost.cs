using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OwlishFileSystem.Components.Primitive
{
    public abstract class OwlishDelegatedFileSystemHost : IOwlishFileSystemHost
    {
        public OwlishDelegatedFileSystemHost()
        {
        }

        public IList<OwlishActionGenDelegater<IOwlishFile, IOwlishPath>> CopyFileAsyncDelegaters { get; private set; }
        public IList<OwlishActionGenDelegater<IOwlishDirectory, IOwlishPath>> CopyDirectoryAsyncDelegaters { get; private set; }
        public IList<OwlishActionGenDelegater<IOwlishFile, IOwlishPath>> MoveFileAsyncDelegaters { get; private set; }
        public IList<OwlishActionGenDelegater<IOwlishDirectory, IOwlishPath>> MoveDirectoryAsyncDelegaters { get; private set; }
        public IList<OwlishActionGenDelegater<IOwlishFile>> RemoveFileAsyncDelegaters { get; private set; }
        public IList<OwlishActionGenDelegater<IOwlishDirectory>> RemoveDirectoryAsyncDelegaters { get; private set; }
        public IList<OwlishFuncGenDelegater<IOwlishFile, bool>> GetIsFileExistAsyncDelegaters { get; private set; }
        public IList<OwlishFuncGenDelegater<IOwlishDirectory, bool>> GetIsDirectoryExistAsyncDelegaters { get; private set; }
        public IList<OwlishFuncGenDelegater<IOwlishPath, PathExistResult>> GetIsPathExistAsyncDelegaters { get; private set; }
        public IList<OwlishFuncGenDelegater<IOwlishFile, System.IO.Stream>> GetFileStreamToReadAsyncDelegaters { get; private set; }
        public IList<OwlishFuncGenDelegater<IOwlishFile, bool, System.IO.Stream>> GetFileStreamToWriteAsyncDelegaters { get; private set; }
        public IList<OwlishFuncGenDelegater<IOwlishPath, IOwlishFile>> CreateFileAsyncDelegaters { get; private set; }
        public IList<OwlishFuncGenDelegater<IOwlishPath, IOwlishDirectory>> CreateDirectoryAsyncDelegaters { get; private set; }



        protected abstract IList<T> InitializeList<T>();

        public Task CopyFileAsync(IOwlishFile file, IOwlishPath newPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            return CopyFileAsyncDelegaters.InvokeIfHasTarget(file, newPath, progressObserver, ct);
        }

        public Task CopyDirectoryAsync(IOwlishDirectory directory, IOwlishPath newPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            return CopyDirectoryAsyncDelegaters.InvokeIfHasTarget(directory, newPath, progressObserver, ct);
        }

        public Task MoveFileAsync(IOwlishFile file, IOwlishPath newPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            return MoveFileAsyncDelegaters.InvokeIfHasTarget(file, newPath, progressObserver, ct);
        }

        public Task MoveDirectoryAsync(IOwlishDirectory directory, IOwlishPath newPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            return MoveDirectoryAsyncDelegaters.InvokeIfHasTarget(directory, newPath, progressObserver, ct);
        }

        public Task RemoveFileAsync(IOwlishFile file, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            return RemoveFileAsyncDelegaters.InvokeIfHasTarget(file, progressObserver, ct);
        }

        public Task RemoveDirectoryAsync(IOwlishDirectory directory, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            return RemoveDirectoryAsyncDelegaters.InvokeIfHasTarget(directory, progressObserver, ct);
        }

        public Task<bool> GetIsFileExistAsync(IOwlishFile file, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            return GetIsFileExistAsyncDelegaters.InvokeIfHasTarget(file, progressObserver, ct);
        }

        public Task<bool> GetIsDirectoryExistAsync(IOwlishDirectory directory, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            return GetIsDirectoryExistAsyncDelegaters.InvokeIfHasTarget(directory, progressObserver, ct);
        }

        public Task<PathExistResult> GetIsPathExistAsync(IOwlishPath path, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            return GetIsPathExistAsyncDelegaters.InvokeIfHasTarget(path, progressObserver, ct);
        }

        public Task<System.IO.Stream> GetFileStreamToReadAsync(IOwlishFile file, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            return GetFileStreamToReadAsyncDelegaters.InvokeIfHasTarget(file, progressObserver, ct);
        }

        public Task<System.IO.Stream> GetFileStreamToWriteAsync(IOwlishFile file, IObserver<OwlishProgress> progressObserver, CancellationToken ct, bool append = false)
        {
            return GetFileStreamToWriteAsyncDelegaters.InvokeIfHasTarget(file, append, progressObserver, ct);
        }

        public Task<IOwlishFile> CreateFileAsync(IOwlishPath path, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            return CreateFileAsyncDelegaters.InvokeIfHasTarget(path, progressObserver, ct);
        }

        public Task<IOwlishDirectory> CreateDirectryAsync(IOwlishPath path, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            return CreateDirectoryAsyncDelegaters.InvokeIfHasTarget(path, progressObserver, ct);
        }
    }
}
