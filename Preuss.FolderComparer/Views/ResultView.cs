using Preuss.FolderComparer.Abstractions.Processors;
using Preuss.FolderComparer.Comparer.Abstractions.DataClasses;

namespace Preuss.FolderComparer.Views;

public class ResultView
{
	private readonly IResultProcessor _processor;

	public ResultView(IResultProcessor processor)
	{
		_processor = processor;
	}

	public void Print(string path, string source, string analogy, IEnumerable<ComparedFileResult> results)
	{
		Console.WriteLine("Successfully compared");

		if (!results.Any())
		{
			Console.WriteLine("Folders are equal");
			Console.ReadKey();
		}
		else
		{
			var missingInSource = _processor.GetMissingFilesForSource(analogy, results);
			var missingInAnalogy = _processor.GetMissingFilesForSource(source, results);

			Console.WriteLine($"Missing files in {source}: {missingInSource.Count()}");
			Console.WriteLine($"Missing files in {analogy}: {missingInAnalogy.Count()}");
        }

		Console.WriteLine("\nDo you want to save the result? (Y/n)");
		var saveResult = Console.ReadLine();

		if (saveResult is null) return;

		if (saveResult.ToLower() == "n") return;

		if (saveResult.ToLower() == "y" || saveResult == "")
		{
			_processor.WriteResultsToFile(path, source, analogy, results);
		}

		Console.WriteLine("Successfully saved result");

        Console.ReadKey();
    }
}

