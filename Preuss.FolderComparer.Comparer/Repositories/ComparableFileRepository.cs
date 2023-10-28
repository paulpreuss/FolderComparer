using Preuss.FolderComparer.Comparer.Abstractions.DataClasses;
using Preuss.FolderComparer.Comparer.Abstractions.Exceptions;
using Preuss.FolderComparer.Comparer.Abstractions.Repositories;
using System.IO.Abstractions;
using System.Security.Cryptography;
using System.Text;

namespace Preuss.FolderComparer.Comparer.Repositories;

public class ComparableFileRepository : IComparableFileRepository
{
    private readonly IFileSystem _fileSystem;

    public ComparableFileRepository(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public IEnumerable<ComparableFile> GetFiles(string path)
    {
        try
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
        catch (IOException ex)
        {
            throw new ComparerDataAccessException($"Could read files of {path}. Probably it is a file path. Please enter a valid folder path.", ex);
        }
        catch (UnauthorizedAccessException ex)
        {
            throw new UnauthorizedAccessException($"Access to {path} denied.", ex);
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException($"{path} is not a valid path.", ex);
        }
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
        file.DateOfChange = _fileSystem.File.GetLastWriteTime(path);

        return file;
    }

    private string ComputeHash(string fileContent)
    {
        var hash = MD5.HashData(Encoding.UTF8.GetBytes(fileContent));

        return BitConverter.ToString(hash).Replace("-", "");
    }
}
