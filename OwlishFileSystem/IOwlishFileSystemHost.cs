using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OwlishFileSystem
{
    public class PathExistResult : IEquatable<PathExistResult>
    {
        public static readonly PathExistResult None = new PathExistResult();
        public static readonly PathExistResult File = new PathExistResult();
        public static readonly PathExistResult Directory = new PathExistResult();

        public virtual bool Equals(PathExistResult other)
        {
            if (this == None && other == null)
            {
                return true;
            }
            else
            {
                return this == other;
            }
        }
    }

    public interface IOwlishFileSystemHost
    {
        void MoveFileAsync(IOwlishFile file, IOwlishPath newPath, CancellationToken ct);
        void MoveDirectoryAsync(IOwlishDirectory directory, IOwlishPath newPath, CancellationToken ct);
        void RemoveFileAsync(IOwlishFile file, CancellationToken ct);
        void RemoveDirectoryAsync(IOwlishDirectory directory, CancellationToken ct);
        bool GetIsFileExistAsync(IOwlishPath path, CancellationToken ct);
        bool GetIsDirectoryExistAsync(IOwlishPath path, CancellationToken ct);
        PathExistResult GetIsPathExistAsync(IOwlishPath path, CancellationToken ct);
        System.IO.Stream OpenFileToReadAsync(IOwlishPath path, CancellationToken ct);
        System.IO.Stream OpenFileToWriteAsync(IOwlishPath path, CancellationToken ct, bool append = false);
        IOwlishDirectory CreateDirectryAsync(IOwlishPath path, CancellationToken ct);
        IOwlishPropertyValue GetProperty(IOwlishFile target, IOwlishProperty property, CancellationToken ct);
        IOwlishPropertyValue GetProperty(IOwlishDirectory directory, IOwlishProperty property, CancellationToken ct);
        IEnumerable<IOwlishObject> EnumerateObjects(IOwlishDirectory directory, CancellationToken ct);
        IEnumerable<IOwlishFile> EnumerateFiles(IOwlishDirectory directory, CancellationToken ct);
        IEnumerable<IOwlishDirectory> EnumerateDirectories(IOwlishDirectory directory, CancellationToken ct);
    }


}
