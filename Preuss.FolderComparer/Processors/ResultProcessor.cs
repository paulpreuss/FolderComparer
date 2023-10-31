using System.IO.Abstractions;
using Preuss.FolderComparer.Abstractions.Processors;

namespace Preuss.FolderComparer.Processors;

public class ResultProcessor : IResultProcessor
{
	private readonly IFileSystem _fileSystem;

	public ResultProcessor(IFileSystem fileSystem)
	{
		_fileSystem = fileSystem;
	}

    public void WriteResultsToFile(string path)
    {
        throw new NotImplementedException();
    }
}

