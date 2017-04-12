using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OwlishFileSystem.SystemIO
{
    public sealed class FileSystemHost : Generic.OwlishFileSystemHost<File, Directory, Path>
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

        public override Directory CreateDirectryAsync(Path path, CancellationToken ct)
        {
            var di = System.IO.Directory.CreateDirectory(path.ToString());
            return new Directory(new Path(this, di.FullName));
        }

        public override Stream OpenFileToReadAsync(Path path, CancellationToken ct)
        {
            return System.IO.File.OpenRead(path.ToString());
        }

        public override Stream OpenFileToWriteAsync(Path path, CancellationToken ct, bool append = false)
        {
            return System.IO.File.OpenWrite(path.ToString());
        }

        public override bool GetIsDirectoryExistAsync(Path path, CancellationToken ct)
        {
            return System.IO.Directory.Exists(path.ToString());
        }

        public override bool GetIsFileExistAsync(Path path, CancellationToken ct)
        {
            return System.IO.File.Exists(path.ToString());
        }

        public override PathExistResult GetIsPathExistAsync(Path path, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public override void MoveDirectoryAsync(Directory directory, Path newPath, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public override void MoveFileAsync(File file, Path newPath, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public override void RemoveDirectoryAsync(Directory directory, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public override void RemoveFileAsync(File file, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public override IOwlishPropertyValue GetProperty(File target, IOwlishProperty property, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public override IOwlishPropertyValue GetProperty(Directory directory, IOwlishProperty property, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<IOwlishObject> EnumerateObjects(Directory directory, CancellationToken ct)
        {
            return EnumerateDirectories(directory, ct).Cast<IOwlishObject>().Concat(EnumerateFiles(directory, ct));
        }

        public override IEnumerable<File> EnumerateFiles(IOwlishDirectory directory, CancellationToken ct)
        {
            return System.IO.Directory.EnumerateFiles(directory.Path.ToString()).Select(p => new File(new Path(this, p)));
        }

        public override IEnumerable<Directory> EnumerateDirectories(IOwlishDirectory directory, CancellationToken ct)
        {
            return System.IO.Directory.EnumerateDirectories(directory.Path.ToString()).Select(p => new Directory(new Path(this, p)));
        }
    }
}
