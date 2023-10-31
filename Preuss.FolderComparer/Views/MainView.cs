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
                Compare(o.Source, o.Analogy);
            }
            else
            {

                ReadFolders();
            }
        });
	}

	private void ReadFolders()
	{
        string? source;
        do
        {
            Console.WriteLine("Please enter the path of the first folder.");
            source = Console.ReadLine();
            if (!_fileSystem.Directory.Exists(source)) Console.WriteLine("The entered folder does not exist.");
        }
        while (!_fileSystem.Directory.Exists(source));

        string? analogy;
        do
        {
            Console.WriteLine("Please enter the path of the second folder.");
            analogy = Console.ReadLine();
            if (!_fileSystem.Directory.Exists(analogy)) Console.WriteLine("The entered folder does not exist.");
        }
        while (!_fileSystem.Directory.Exists(analogy));

        Compare(source, analogy);
    }

	private void Compare(string source, string analogy)
	{
        if (_fileSystem.Directory.Exists(source)
            && _fileSystem.Directory.Exists(analogy))
        {
            var results = _comparer.GetComparedFileResults(source, analogy);

            _resultView.Print(source, analogy, results);
        }
    }
}