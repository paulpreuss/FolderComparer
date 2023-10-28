using Preuss.FolderComparer.DataAccess.Abstractions.DataClasses;

namespace Preuss.FolderComparer.DataAccess.Abstractions.Repositories;

public interface IComparableFileRepository
{
    IEnumerable<ComparableFile> GetFiles(string path);
}
