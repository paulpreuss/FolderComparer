using Preuss.FolderComparer.Abstractions.Processors;

namespace Preuss.FolderComparer.Processors;

public class ArgumentsProcessor : IArgumentsProcessor
{
	private readonly string[] _args;

	public ArgumentsProcessor(string[] args)
	{
		_args = args;
	}

    public bool ProvidedTwoFolders()
    {
        return _args.Length == 2;
    }

    public string GetFirstFolder()
    {
        throw new NotImplementedException();
    }

    public string GetSecondFolder()
    {
        throw new NotImplementedException();
    }
}

