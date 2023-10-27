using Preuss.FolderComparer.Abstractions.Processors;

namespace Preuss.FolderComparer.Views;

public class MainView
{
	private readonly IArgumentsProcessor _argumentsProcessor;
	private readonly ResultView _resultView;

	public MainView(IArgumentsProcessor argumentsProcessor, ResultView resultView)
	{
		_argumentsProcessor = argumentsProcessor;
		_resultView = resultView;
    }

	public void Print()
	{
		if (_argumentsProcessor.ProvidedTwoFolders())
		{
			Compare(_argumentsProcessor.GetFirstFolder(),
				_argumentsProcessor.GetSecondFolder());
		}
		else
		{
			Console.WriteLine("Please enter the path of the first folder.");
			var firstFolder = Console.ReadLine();
            Console.WriteLine("Please enter the path of the second folder.");
			var secondFolder = Console.ReadLine();

			Compare(firstFolder, secondFolder);
        }
	}

	private void Compare(string firstFolder, string secondFolder)
	{

	}
}