using Preuss.FolderComparer.Comparer.Abstractions.Enums;

namespace Preuss.FolderComparer.Comparer.Abstractions.DataClasses;

public class ComparedFileResult
{
	public string Id { get; set; } = string.Empty;
	public string Path { get; set; } = string.Empty;
	public string Source { get; set; } = string.Empty;
	public CompareResult Result { get; set; }
}

