using System.IO.Abstractions;
using Preuss.FolderComparer.Abstractions.Processors;
using Preuss.FolderComparer.Comparer.Abstractions.DataClasses;

namespace Preuss.FolderComparer.Processors;

public class ResultProcessor : IResultProcessor
{
	private readonly IFileSystem _fileSystem;

	public ResultProcessor(IFileSystem fileSystem)
	{
		_fileSystem = fileSystem;
	}

    public void WriteResultsToFile(string path, string source, string analogy, IEnumerable<ComparedFileResult> results)
    {
		var missingInSource = GetMissingFilesForSource(analogy, results);
        var missingInAnalogy = GetMissingFilesForSource(source, results);

        _fileSystem.File.AppendAllText(path, $"Following files are missing in {source}:\n");
		foreach (var file in missingInSource)
		{
			_fileSystem.File.AppendAllText(path, $"{file.Result}: {file.Path}\n");
		}

        _fileSystem.File.AppendAllText(path, $"\nFollowing files are missing in {analogy}:\n");
        foreach (var file in missingInAnalogy)
        {
            _fileSystem.File.AppendAllText(path, $"{file.Result}: {file.Path}\n");
        }
    }

	public IEnumerable<ComparedFileResult> GetMissingFilesForSource(string source, IEnumerable<ComparedFileResult> results)
	{
		return results.Where(x => x.Source == source);
	}
}

