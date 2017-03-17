using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OwlishFileSystem.SystemIO
{
    public sealed class FileSystemHost : OwlishFileSystem.Generic.OwlishFileSystemHost<File, Directory, Path>
    {
        private FileSystemHost()
        {

        }

        private static FileSystemHost _instance;
        public static FileSystemHost Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FileSystemHost();
                }
                return _instance;
            }
        }

        public override Task<Directory> CreateDirectryAsync(Path path, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public override Task<File> CreateFileAsync(Path path, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public override Task<Stream> GetFileStreamToReadAsync(File file, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public override Task<Stream> GetFileStreamToWriteAsync(File file, IObserver<OwlishProgress> progressObserver, CancellationToken ct, bool append = false)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> GetIsDirectoryExistAsync(Directory directory, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> GetIsFileExistAsync(File file, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public override Task<PathExistResult> GetIsPathExistAsync(Path path, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public override Task MoveDirectoryAsync(Directory directory, Path newPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public override Task MoveFileAsync(File file, Path newPath, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public override Task RemoveDirectoryAsync(Directory directory, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public override Task RemoveFileAsync(File file, IObserver<OwlishProgress> progressObserver, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
