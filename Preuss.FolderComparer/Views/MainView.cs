using CommandLine;
using System.IO.Abstractions;
using Preuss.FolderComparer.Abstractions.DataClasses;
using Preuss.FolderComparer.Abstractions.Processors;
using Preuss.FolderComparer.Comparer.Abstractions;

namespace Preuss.FolderComparer.Views;

public class MainView
{
	private readonly IFileSystem _fileSystem;
	private readonly IArgumentsProcessor _argumentsProcessor;
    private readonly IComparableFileComparer _comparer;
	private readonly ResultView _resultView;

	public MainView(IFileSystem fileSystem, IArgumentsProcessor argumentsProcessor,
        IComparableFileComparer comparer, ResultView resultView)
	{
		_fileSystem = fileSystem;
		_argumentsProcessor = argumentsProcessor;
        _comparer = comparer;
		_resultView = resultView;
    }

	public void Print()
	{
		var args = _argumentsProcessor.GetArgs();

		Parser.Default.ParseArguments<CommandLineOptions>(args).WithParsed(o =>
		{
			if (!string.IsNullOrEmpty(o.Source) && !string.IsNullOrEmpty(o.Analogy))
			{
                Compare(o.Path, o.Source, o.Analogy);
            }
        });
	}

	private void Compare(string path, string source, string analogy)
	{
        if (_fileSystem.Directory.Exists(source)
            && _fileSystem.Directory.Exists(analogy))
        {
            var results = _comparer.GetComparedFileResults(source, analogy);

            _resultView.Print(path, source, analogy, results);
        }
    }
}