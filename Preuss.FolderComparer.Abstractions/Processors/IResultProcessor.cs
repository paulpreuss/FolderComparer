using Preuss.FolderComparer.Comparer.Abstractions.DataClasses;

namespace Preuss.FolderComparer.Abstractions.Processors;

public interface IResultProcessor
{
    void WriteResultsToFile(string path, string source, string analogy, IEnumerable<ComparedFileResult> results);
    IEnumerable<ComparedFileResult> GetMissingFilesForSource(string source, IEnumerable<ComparedFileResult> results);
}

