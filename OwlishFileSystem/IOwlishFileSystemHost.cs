using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OwlishFileSystem
{
    public enum PathExistResult
    {
        None,
        File,
        Directory,
        Other
    }

    public interface IOwlishFileSystemHost
    {
        Task CopyFileAsync(IOwlishFile file, IOwlishPath newPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        Task CopyDirectoryAsync(IOwlishDirectory directory, IOwlishPath newPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        Task MoveFileAsync(IOwlishFile file, IOwlishPath newPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        Task MoveDirectoryAsync(IOwlishDirectory directory, IOwlishPath newPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        Task RemoveFileAsync(IOwlishFile file, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        Task RemoveDirectoryAsync(IOwlishDirectory directory, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        Task<bool> GetIsFileExistAsync(IOwlishFile file, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        Task<bool> GetIsDirectoryExistAsync(IOwlishDirectory directory, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        Task<PathExistResult> GetIsPathExistAsync(IOwlishPath path, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        Task<System.IO.Stream> GetFileStreamToReadAsync(IOwlishFile file, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        Task<System.IO.Stream> GetFileStreamToWriteAsync(IOwlishFile file, IObserver<OwlishProgress> progressObserver, CancellationToken ct, bool append = false);
        Task<IOwlishFile> CreateFileAsync(IOwlishPath path, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        Task<IOwlishDirectory> CreateDirectryAsync(IOwlishPath path, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
    }

    public static class IOwlishFileSystemHostExtentions
    {
        public static Task CopyFileAsync(this IOwlishFileSystemHost _this, IOwlishFile file, IOwlishPath newPath, CancellationToken ct)
        {
            return _this.CopyFileAsync(file, newPath, new BlankObserver<OwlishProgress>(), ct);
        }

        public static Task CopyDirectoryAsync(this IOwlishFileSystemHost _this, IOwlishDirectory directory, IOwlishPath newPath, CancellationToken ct)
        {
            return _this.CopyDirectoryAsync(directory, newPath, new BlankObserver<OwlishProgress>(), ct);
        }

        public static Task MoveFileAsync(this IOwlishFileSystemHost _this, IOwlishFile file, IOwlishPath newPath, CancellationToken ct)
        {
            return _this.MoveFileAsync(file, newPath, new BlankObserver<OwlishProgress>(), ct);
        }

        public static Task MoveDirectoryAsync(this IOwlishFileSystemHost _this, IOwlishDirectory directory, IOwlishPath newPath, CancellationToken ct)
        {
            return _this.MoveDirectoryAsync(directory, newPath, new BlankObserver<object>(), ct);
        }

        public static Task<bool> GetIsFileExisitAsync(this IOwlishFileSystemHost _this, IOwlishFile file, CancellationToken ct)
        {
            return _this.GetIsFileExistAsync(file, new BlankObserver<object>(), ct);
        }

        public static Task<bool> GetIsDirectoryExisitAsync(this IOwlishFileSystemHost _this, IOwlishDirectory directory, CancellationToken ct)
        {
            return _this.GetIsDirectoryExistAsync(directory, new BlankObserver<object>(), ct);
        }

        public static Task<PathExistResult> GetIsPathExisitAsync(this IOwlishFileSystemHost _this, IOwlishPath directoryPath, CancellationToken ct)
        {
            return _this.GetIsPathExistAsync(directoryPath, new BlankObserver<object>(), ct);
        }

        public static Task<System.IO.Stream> GetFileStreamToReadAsync(this IOwlishFileSystemHost _this, IOwlishFile file, CancellationToken ct)
        {
            return _this.GetFileStreamToReadAsync(file, new BlankObserver<object>(), ct);
        }

        public static Task<System.IO.Stream> GetFileStreamToWriteAsync(this IOwlishFileSystemHost _this, IOwlishFile file, CancellationToken ct, bool append = false)
        {
            return _this.GetFileStreamToWriteAsync(file, new BlankObserver<object>(), ct);
        }

        public static Task<IOwlishFile> CreateFileAsync(this IOwlishFileSystemHost _this, IOwlishPath path, CancellationToken ct)
        {
            return _this.CreateFileAsync(path, new BlankObserver<object>(), ct);
        }

        public static Task<IOwlishDirectory> CreateDirecotryAsync(this IOwlishFileSystemHost _this, IOwlishPath path, CancellationToken ct)
        {
            return _this.CreateDirectryAsync(path, new BlankObserver<object>(), ct);
        }
    }
}
