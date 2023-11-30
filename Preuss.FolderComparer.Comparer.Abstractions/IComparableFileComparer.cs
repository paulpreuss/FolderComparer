using Preuss.FolderComparer.Comparer.Abstractions.DataClasses;

namespace Preuss.FolderComparer.Comparer.Abstractions;

public interface IComparableFileComparer
{
    IEnumerable<ComparedFileResult> GetComparedFileResults(string folderOne, string folderTwo); 
}
