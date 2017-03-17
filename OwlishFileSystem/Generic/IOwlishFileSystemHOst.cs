using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OwlishFileSystem.Generic
{
    interface IOwlishFileSystemHost<TFile, TDirectory, TPath>
        where TFile : IOwlishFile
        where TDirectory : IOwlishDirectory
        where TPath : IOwlishPath
    {
        Task MoveFileAsync(TFile file, TPath newPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        Task MoveDirectoryAsync(TDirectory directory, TPath newPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        Task RemoveFileAsync(TFile file, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        Task RemoveDirectoryAsync(TDirectory directory, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        Task<bool> GetIsFileExistAsync(TFile file, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        Task<bool> GetIsDirectoryExistAsync(TDirectory directory, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        Task<PathExistResult> GetIsPathExistAsync(TPath path, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        Task<System.IO.Stream> GetFileStreamToReadAsync(TFile file, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        Task<System.IO.Stream> GetFileStreamToWriteAsync(TFile file, IObserver<OwlishProgress> progressObserver, CancellationToken ct, bool append = false);
        Task<TFile> CreateFileAsync(TPath path, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
        Task<TDirectory> CreateDirectryAsync(TPath path, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
    }
}
