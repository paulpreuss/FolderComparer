using Preuss.FolderComparer.DataAccess.Abstractions.DataClasses;
using Preuss.FolderComparer.DataAccess.Abstractions.Repositories;
using System.IO.Abstractions;
using System.Security.Cryptography;
using System.Text;

namespace Preuss.FolderComparer.DataAccess.Repositories;

public class ComparableFileRepository : IComparableFileRepository
{
    private readonly IFileSystem _fileSystem;

    public ComparableFileRepository(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public IEnumerable<ComparableFile> GetFiles(string path)
    {
        var files = new List<ComparableFile>();

        var filesInCurrentDirectory = _fileSystem.Directory.GetFiles(path);
        files.AddRange(GetComparableFiles(filesInCurrentDirectory));

        var directoriesInCurrentDirectory = _fileSystem.Directory.GetDirectories(path);
        if (directoriesInCurrentDirectory is not null 
            && directoriesInCurrentDirectory.Any())
        {
            foreach (var directory in directoriesInCurrentDirectory)
            {
                files.AddRange(GetFiles(directory));
            }
        }

        return files;
    }

    private IEnumerable<ComparableFile> GetComparableFiles(string[]? paths)
    {
        var files = new List<ComparableFile>();

        if (paths is null || paths.Length < 1) return files;

        foreach ( var path in paths)
        {
            files.Add(GetComparableFile(path));
        }

        return files;
    }

    private ComparableFile GetComparableFile(string path)
    {
        var file = new ComparableFile();

        var fileContent = _fileSystem.File.ReadAllText(path);

        file.Hash = ComputeHash(fileContent);
        file.Path = path;

        return file;
    }

    private string ComputeHash(string fileContent)
    {
        var hash = MD5.HashData(Encoding.UTF8.GetBytes(fileContent));

        return BitConverter.ToString(hash).Replace("-", "");
    }
}
