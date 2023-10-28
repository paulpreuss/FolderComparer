using Preuss.FolderComparer.Comparer.Abstractions.DataClasses;

namespace Preuss.FolderComparer.Comparer.Abstractions.Repositories;

public interface IComparableFileRepository
{
    IEnumerable<ComparableFile> GetFiles(string path);
}
