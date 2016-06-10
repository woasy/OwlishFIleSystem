using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OwlishFileSystem.Rx
{
    public delegate Task CopyFileDelegate(IOwlishFile file, IOwlishPath newPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
    public delegate Task CopyDirectoryDelegate(IOwlishDirectory directory, IOwlishPath newPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
    public delegate Task MoveFileDelegate(IOwlishFile file, IOwlishPath newPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
    public delegate Task MoveDirectoryDelegate(IOwlishDirectory directory, IOwlishPath newPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
    public delegate Task<bool> GetIsFileExisitDelegate(IOwlishFile file, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
    public delegate Task<bool> GetIsDirectoryExisitDelegate(IOwlishDirectory directory, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
    public delegate Task<PathExistResult> GetIsPathExisitDelegate(IOwlishPath directoryPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
    public delegate Task<System.IO.Stream> GetFileStreamToReadDelegate(IOwlishFile file, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
    public delegate Task<System.IO.Stream> GetFileStreamToWriteDelegate(IOwlishFile file, IObserver<OwlishProgress> progressObserver, CancellationToken ct, bool append = false);
    public delegate Task<IOwlishFile> CreateFileDelegate(IOwlishPath path, IObserver<OwlishProgress> progressObserver, CancellationToken ct);
    public delegate Task<IOwlishDirectory> CreateDirecotryDelegate(IOwlishPath path, IObserver<OwlishProgress> progressObserver, CancellationToken ct);

    public abstract class OwlishFileSystemHostBase : IOwlishFileSystemHost
    {
        virtual public async Task CopyFileAsync(IOwlishFile file, IOwlishPath newPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            var nf = await this.CreateFileAsync(newPath, progressObserver, ct);
            Exception error = null;
            try
            {
                using (var r = await this.GetFileStreamToReadAsync(file, progressObserver, ct))
                using (var w = await this.GetFileStreamToWriteAsync(nf, progressObserver, ct))
                {

                }
            }
            catch (Exception e)
            {
                error = e;
            }
            if (error != null)
            {
                if (await this.GetIsFileExistAsync(nf, progressObserver, ct))
                {

                }
            }
        }

        virtual public async Task CopyDirectoryAsync(IOwlishDirectory directory, IOwlishPath newPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            await this.CreateDirectryAsync(newPath, progressObserver, ct);
            foreach (var subdir in directory.EnumerateSubDirectories())
            {
                ct.ThrowIfCancellationRequested();
                await this.CopyDirectoryAsync(subdir, newPath.CreateCombinedPath(subdir.Name), progressObserver, ct);
            }
            foreach (var subfi in directory.EnumerateSubFiles())
            {
                ct.ThrowIfCancellationRequested();
                await this.CopyFileAsync(subfi, newPath.CreateCombinedPath(subfi.Name), progressObserver, ct);
            }
        }

        virtual public Task MoveFileAsync(IOwlishFile file, IOwlishPath newPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        virtual public Task MoveDirectoryAsync(IOwlishDirectory directory, IOwlishPath newPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        virtual public Task RemoveFileAsync(IOwlishFile file, IOwlishPath newPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        virtual public Task RemoveDirectoryAsync(IOwlishDirectory directory, IOwlishPath newPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        virtual public Task<bool> GetIsFileExistAsync(IOwlishFile file, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        virtual public Task<bool> GetIsDirectoryExistAsync(IOwlishDirectory directory, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        virtual public Task<PathExistResult> GetIsPathExistAsync(IOwlishPath directoryPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        virtual public Task<System.IO.Stream> GetFileStreamToReadAsync(IOwlishFile file, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        virtual public Task<System.IO.Stream> GetFileStreamToWriteAsync(IOwlishFile file, IObserver<OwlishProgress> progressObserver, CancellationToken ct, bool append = false)
        {
            throw new NotImplementedException();
        }

        virtual public Task<IOwlishFile> CreateFileAsync(IOwlishPath path, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        virtual public Task<IOwlishDirectory> CreateDirectryAsync(IOwlishPath path, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFileAsync(IOwlishFile file, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task RemoveDirectoryAsync(IOwlishDirectory directory, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
