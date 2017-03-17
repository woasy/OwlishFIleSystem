using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OwlishFileSystem.Generic
{
    public abstract class OwlishFileSystemHost<TFile, TDirectory, TPath> : IOwlishFileSystemHost, IOwlishFileSystemHost<TFile, TDirectory, TPath>
        where TFile : class, IOwlishFile
        where TDirectory : class, IOwlishDirectory
        where TPath : class, IOwlishPath
    {
        public abstract Task<TDirectory> CreateDirectryAsync(TPath path, IObserver<OwlishProgress> progressObserver, CancellationToken ct);

        public abstract Task<TFile> CreateFileAsync(TPath path, IObserver<OwlishProgress> progressObserver, CancellationToken ct);

        public abstract Task<Stream> GetFileStreamToReadAsync(TFile file, IObserver<OwlishProgress> progressObserver, CancellationToken ct);

        public abstract Task<Stream> GetFileStreamToWriteAsync(TFile file, IObserver<OwlishProgress> progressObserver, CancellationToken ct, bool append = false);

        public abstract Task<bool> GetIsDirectoryExistAsync(TDirectory directory, IObserver<OwlishProgress> progressObserver, CancellationToken ct);

        public abstract Task<bool> GetIsFileExistAsync(TFile file, IObserver<OwlishProgress> progressObserver, CancellationToken ct);

        public abstract Task<PathExistResult> GetIsPathExistAsync(TPath path, IObserver<OwlishProgress> progressObserver, CancellationToken ct);

        public abstract Task MoveDirectoryAsync(TDirectory directory, TPath newPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct);

        public abstract Task MoveFileAsync(TFile file, TPath newPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct);

        public abstract Task RemoveDirectoryAsync(TDirectory directory, IObserver<OwlishProgress> progressObserver, CancellationToken ct);

        public abstract Task RemoveFileAsync(TFile file, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        
        private TResult CheckType<TResult>(IOwlishFile file, IOwlishDirectory directory, IOwlishPath path, Func<TFile, TDirectory, TPath, TResult> func)
        {
            try
            {
                var of = file != null ? (TFile)file : null;
                var od = directory != null ? (TDirectory)directory : null;
                var op = path != null ? (TPath)path : null;
                return func(of, od, op);
            }
            catch (Exception e)
            {
                throw new InvalidTypeOfOwlishFileSystemException("", e);
            }
        }

        async Task<IOwlishDirectory> IOwlishFileSystemHost.CreateDirectryAsync(IOwlishPath path, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            return await CheckType(null, null, path, (f, d, p) => CreateDirectryAsync(p, progressObserver, ct));
        }

        async Task<IOwlishFile> IOwlishFileSystemHost.CreateFileAsync(IOwlishPath path, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            return await CheckType(null, null, path, (f, d, p) => CreateFileAsync(p, progressObserver, ct));
        }

        Task<Stream> IOwlishFileSystemHost.GetFileStreamToReadAsync(IOwlishFile file, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            return CheckType(file, null, null, (f, d, p) => GetFileStreamToReadAsync(f, progressObserver, ct));
        }

        Task<Stream> IOwlishFileSystemHost.GetFileStreamToWriteAsync(IOwlishFile file, IObserver<OwlishProgress> progressObserver, CancellationToken ct, bool append)
        {
            return CheckType(file, null, null, (f, d, p) => GetFileStreamToWriteAsync(f, progressObserver, ct));
        }

        Task<bool> IOwlishFileSystemHost.GetIsDirectoryExistAsync(IOwlishDirectory directory, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            return CheckType(null, directory, null, (f, d, p) => GetIsDirectoryExistAsync(d, progressObserver, ct));
        }

        Task<bool> IOwlishFileSystemHost.GetIsFileExistAsync(IOwlishFile file, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            return CheckType(file, null, null, (f, d, p) => GetIsFileExistAsync(f, progressObserver, ct));
        }

        Task<PathExistResult> IOwlishFileSystemHost.GetIsPathExistAsync(IOwlishPath path, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            return CheckType(null, null, path, (f, d, p) => GetIsPathExistAsync(p, progressObserver, ct));
        }

        Task IOwlishFileSystemHost.MoveDirectoryAsync(IOwlishDirectory directory, IOwlishPath newPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            return CheckType(null, directory, newPath, (f, d, p) => MoveDirectoryAsync(d, p, progressObserver, ct));
        }

        Task IOwlishFileSystemHost.MoveFileAsync(IOwlishFile file, IOwlishPath newPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            return CheckType(file, null, newPath, (f, d, p) => MoveFileAsync(f, p, progressObserver, ct));
        }

        Task IOwlishFileSystemHost.RemoveDirectoryAsync(IOwlishDirectory directory, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            return CheckType(null, directory, null, (f, d, p) => RemoveDirectoryAsync(d, progressObserver, ct));
        }

        Task IOwlishFileSystemHost.RemoveFileAsync(IOwlishFile file, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            return CheckType(file, null, null, (f, d, p) => RemoveFileAsync(f, progressObserver, ct));
        }
    }
}
