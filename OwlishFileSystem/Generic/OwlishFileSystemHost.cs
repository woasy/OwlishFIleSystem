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
        public abstract TDirectory CreateDirectryAsync(TPath path, CancellationToken ct);
        public abstract Stream OpenFileToReadAsync(TPath path, CancellationToken ct);
        public abstract Stream OpenFileToWriteAsync(TPath path, CancellationToken ct, bool append = false);
        public abstract bool GetIsDirectoryExistAsync(TPath path, CancellationToken ct);
        public abstract bool GetIsFileExistAsync(TPath path, CancellationToken ct);
        public abstract PathExistResult GetIsPathExistAsync(TPath path, CancellationToken ct);
        public abstract void MoveDirectoryAsync(TDirectory directory, TPath newPath, CancellationToken ct);
        public abstract void MoveFileAsync(TFile file, TPath newPath, CancellationToken ct);
        public abstract void RemoveDirectoryAsync(TDirectory directory, CancellationToken ct);
        public abstract void RemoveFileAsync(TFile file, CancellationToken ct);
        public abstract IOwlishPropertyValue GetProperty(TFile target, IOwlishProperty property, CancellationToken ct);
        public abstract IOwlishPropertyValue GetProperty(TDirectory directory, IOwlishProperty property, CancellationToken ct);
        public abstract IEnumerable<IOwlishObject> EnumerateObjects(TDirectory directory, CancellationToken ct);
        public abstract IEnumerable<TFile> EnumerateFiles(IOwlishDirectory directory, CancellationToken ct);
        public abstract IEnumerable<TDirectory> EnumerateDirectories(IOwlishDirectory directory, CancellationToken ct);

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

        private void CheckType(IOwlishFile file, IOwlishDirectory directory, IOwlishPath path, Action<TFile, TDirectory, TPath> func)
        {
            CheckType<object>(file, directory, path, (f, d, p) => { func(f, d, p); return null; });
        }

        IOwlishDirectory IOwlishFileSystemHost.CreateDirectryAsync(IOwlishPath path, CancellationToken ct)
            => CheckType(null, null, path, (f, d, p) => CreateDirectryAsync(p, ct));
        
        Stream IOwlishFileSystemHost.OpenFileToReadAsync(IOwlishPath path, CancellationToken ct)
            => CheckType(null, null, path, (f, d, p) => OpenFileToReadAsync(p, ct));

        Stream IOwlishFileSystemHost.OpenFileToWriteAsync(IOwlishPath path, CancellationToken ct, bool append)
            => CheckType(null, null, path, (f, d, p) => OpenFileToWriteAsync(p, ct));

        bool IOwlishFileSystemHost.GetIsDirectoryExistAsync(IOwlishPath path, CancellationToken ct)
            => CheckType(null, null, path, (f, d, p) => GetIsDirectoryExistAsync(p, ct));

        bool IOwlishFileSystemHost.GetIsFileExistAsync(IOwlishPath path, CancellationToken ct)
            => CheckType(null, null, path, (f, d, p) => GetIsFileExistAsync(p, ct));

        PathExistResult IOwlishFileSystemHost.GetIsPathExistAsync(IOwlishPath path, CancellationToken ct)
            => CheckType(null, null, path, (f, d, p) => GetIsPathExistAsync(p, ct));

        void IOwlishFileSystemHost.MoveDirectoryAsync(IOwlishDirectory directory, IOwlishPath newPath, CancellationToken ct)
            => CheckType(null, directory, newPath, (f, d, p) => MoveDirectoryAsync(d, p, ct));

        void IOwlishFileSystemHost.MoveFileAsync(IOwlishFile file, IOwlishPath newPath, CancellationToken ct)
            => CheckType(file, null, newPath, (f, d, p) => MoveFileAsync(f, p, ct));

        void IOwlishFileSystemHost.RemoveDirectoryAsync(IOwlishDirectory directory, CancellationToken ct)
            => CheckType(null, directory, null, (f, d, p) => RemoveDirectoryAsync(d, ct));

        void IOwlishFileSystemHost.RemoveFileAsync(IOwlishFile file, CancellationToken ct)
            => CheckType(file, null, null, (f, d, p) => RemoveFileAsync(f, ct));

        IOwlishPropertyValue IOwlishFileSystemHost.GetProperty(IOwlishFile target, IOwlishProperty property, CancellationToken ct)
            => CheckType(target, null, null, (f, d, p) => GetProperty(f, property, ct));

        IOwlishPropertyValue IOwlishFileSystemHost.GetProperty(IOwlishDirectory directory, IOwlishProperty property, CancellationToken ct)
            => CheckType(null, directory, null, (f, d, p) => GetProperty(d, property, ct));

        IEnumerable<IOwlishObject> IOwlishFileSystemHost.EnumerateObjects(IOwlishDirectory directory, CancellationToken ct)
            => CheckType(null, directory, null, (f, d, p) => EnumerateObjects(d, ct));

        IEnumerable<IOwlishFile> IOwlishFileSystemHost.EnumerateFiles(IOwlishDirectory directory, CancellationToken ct)
            => CheckType(null, directory, null, (f, d, p) => EnumerateFiles(d, ct));

        IEnumerable<IOwlishDirectory> IOwlishFileSystemHost.EnumerateDirectories(IOwlishDirectory directory, CancellationToken ct)
            => CheckType(null, directory, null, (f, d, p) => EnumerateDirectories(d, ct));
    }
}
