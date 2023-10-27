namespace Preuss.FolderComparer.Abstractions.Processors;

public interface IArgumentsProcessor
{
    bool ProvidedTwoFolders();
    string GetFirstFolder();
    string GetSecondFolder();
}