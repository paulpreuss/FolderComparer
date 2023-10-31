using Preuss.FolderComparer.Abstractions.Processors;

namespace Preuss.FolderComparer.Processors;

public class ArgumentsProcessor : IArgumentsProcessor
{
	private readonly string[] _args;

	public ArgumentsProcessor(string[] args)
	{
		_args = args;
	}

    public string[] GetArgs()
	{
		return _args;
	}
}

