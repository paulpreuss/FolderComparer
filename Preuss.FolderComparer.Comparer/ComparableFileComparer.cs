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

        var results = CompareFiles(filesFromFolderOne, filesFromFolderTwo);

        return results;
    }

    private IEnumerable<ComparedFileResult> CompareFiles(IEnumerable<ComparableFile> filesFromFolderOne,
        IEnumerable<ComparableFile> filesFromFolderTwo)
    {
        var missingInFolderTwo = new List<ComparedFileResult>();

        foreach (var fileOne in filesFromFolderOne)
        {
            if (filesFromFolderTwo.Any(x => x.Hash == fileOne.Hash)) continue;

            missingInFolderTwo.Add(new ComparedFileResult
            {
                Path = fileOne.Path,
                Result = CompareResult.Missing
            });
        }

        return missingInFolderTwo;
    }
}