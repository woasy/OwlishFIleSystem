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
        void MoveFileAsync(TFile file, TPath newPath, CancellationToken ct);
        void MoveDirectoryAsync(TDirectory directory, TPath newPath, CancellationToken ct);
        void RemoveFileAsync(TFile file, CancellationToken ct);
        void RemoveDirectoryAsync(TDirectory directory, CancellationToken ct);
        bool GetIsFileExistAsync(TPath path, CancellationToken ct);
        bool GetIsDirectoryExistAsync(TPath path, CancellationToken ct);
        PathExistResult GetIsPathExistAsync(TPath path, CancellationToken ct);
        System.IO.Stream OpenFileToReadAsync(TPath path, CancellationToken ct);
        System.IO.Stream OpenFileToWriteAsync(TPath path, CancellationToken ct, bool append = false);
        TDirectory CreateDirectryAsync(TPath path, CancellationToken ct);
        IOwlishPropertyValue GetProperty(TFile target, IOwlishProperty property, CancellationToken ct);
        IOwlishPropertyValue GetProperty(TDirectory directory, IOwlishProperty property, CancellationToken ct);
        IEnumerable<IOwlishObject> EnumerateObjects(TDirectory directory, CancellationToken ct);
        IEnumerable<TFile> EnumerateFiles(IOwlishDirectory directory, CancellationToken ct);
        IEnumerable<TDirectory> EnumerateDirectories(IOwlishDirectory directory, CancellationToken ct);
    }
}
