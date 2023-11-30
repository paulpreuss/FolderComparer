using CommandLine;

namespace Preuss.FolderComparer.Abstractions.DataClasses;

public class CommandLineOptions
{
	[Option('s', "source", Required = true, HelpText = "The path of you source folder.")]
	public string Source { get; set; } = string.Empty;

    [Option('a', "analogy", Required = true, HelpText = "The path of you analogy folder.")]
    public string Analogy { get; set; } = string.Empty;

    [Option('p', "path", Required = true, HelpText = "The path of the result file.")]
    public string Path { get; set; } = string.Empty;
}

