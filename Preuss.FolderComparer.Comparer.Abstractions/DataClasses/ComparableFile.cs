namespace Preuss.FolderComparer.Comparer.Abstractions.DataClasses;

public class ComparableFile
{
    public string Id { get; set; } = string.Empty;
    public string Hash { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
}
