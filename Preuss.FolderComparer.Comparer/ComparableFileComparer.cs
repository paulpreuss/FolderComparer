using Preuss.FolderComparer.Comparer.Abstractions;
using Preuss.FolderComparer.Comparer.Abstractions.DataClasses;
using Preuss.FolderComparer.Comparer.Abstractions.Enums;
using Preuss.FolderComparer.Comparer.Abstractions.Repositories;

namespace Preuss.FolderComparer.Comparer;

public class ComparableFileComparer : IComparableFileComparer
{
    private readonly IComparableFileRepository _repository;

    public ComparableFileComparer(IComparableFileRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<ComparedFileResult> GetComparedFileResults(string source, string analogy)
    {
        var filesFromSource = _repository.GetFiles(source);
        var filesFromAnalogy = _repository.GetFiles(analogy);

        var results = new List<ComparedFileResult>();

        foreach (var file in filesFromSource)
        {
            if (filesFromAnalogy.Any(x => x.Hash == file.Hash)) continue;

            results.Add(new ComparedFileResult
            {
                Path = file.Path,
                Source = source,
                Result = CompareResult.Missing
            });
        }

        foreach (var file in filesFromAnalogy)
        {
            if (filesFromSource.Any(x => x.Hash == file.Hash)) continue;

            results.Add(new ComparedFileResult
            {
                Path = file.Path,
                Source = analogy,
                Result = CompareResult.Missing
            });
        }

        return results;
    }
}