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

    public IEnumerable<ComparedFileResult> GetComparedFileResults(string folderOne, string folderTwo)
    {
        var filesFromFolderOne = _repository.GetFiles(folderOne);
        var filesFromFolderTwo = _repository.GetFiles(folderTwo);

        var results = new List<ComparedFileResult>();

        var missingInFolderTwo = new List<ComparedFileResult>();

        foreach (var fileOne in filesFromFolderOne)
        {
            if (filesFromFolderTwo.Any(x => x.Hash == fileOne.Hash)) continue;

            missingInFolderTwo.Add(new ComparedFileResult
            {
                Path = fileOne.Path,
                Source = folderOne,
                Result = CompareResult.Missing
            });
        }
        results.AddRange(missingInFolderTwo);

        var missingInFolderOne = new List<ComparedFileResult>();

        foreach (var fileTwo in filesFromFolderTwo)
        {
            if (filesFromFolderOne.Any(x => x.Hash == fileTwo.Hash)) continue;

            missingInFolderOne.Add(new ComparedFileResult
            {
                Path = fileTwo.Path,
                Source = folderTwo,
                Result = CompareResult.Missing
            });
        }
        results.AddRange(missingInFolderOne);

        return results;
    }
}