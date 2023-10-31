using Preuss.FolderComparer.Comparer.Abstractions.DataClasses;

namespace Preuss.FolderComparer.Views;

public class ResultView
{
	public void Print(string source, string analogy, IEnumerable<ComparedFileResult> results)
	{
		if (!results.Any())
		{
			Console.WriteLine("Folders are equal.");
			Console.ReadKey();
			return;
		}

		foreach (var result in results)
		{
			Console.WriteLine($"{result.Result}: {result.Path}");
		}

        Console.ReadKey();
    }
}

