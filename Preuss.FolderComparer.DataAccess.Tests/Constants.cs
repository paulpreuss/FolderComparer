using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;

namespace Preuss.FolderComparer.DataAccess.Tests;

public static class Constants
{
    public static IFileSystem FileSystemWithNoFiles = new MockFileSystem(new Dictionary<string, MockFileData>
    {
        { "C:\\somefolder\\", new MockDirectoryData() }
    });

    public static IFileSystem FileSystemWithFiles = new MockFileSystem(new Dictionary<string, MockFileData>
    {
        { "C:\\test.txt", new MockFileData("something") }
    });

    public static IFileSystem FileSystemWithEqualFiles = new MockFileSystem(new Dictionary<string, MockFileData>
    {
        { "C:\\folder1\\equalfile.txt", new MockFileData("equal content") },
        { "C:\\folder2\\equalfile.txt", new MockFileData("equal content") }
    });

    public static IFileSystem FileSystemWithSimilarFiles = new MockFileSystem(new Dictionary<string, MockFileData>
    {
        { "C:\\folder1\\equalfile.txt", new MockFileData("equal content") },
        { "C:\\folder1\\differentfile.txt", new MockFileData("different content one") },
        { "C:\\folder2\\equalfile.txt", new MockFileData("equal content") },
        { "C:\\folder2\\differentfile.txt", new MockFileData("different content two") },
    });

    public static IFileSystem FileSystemWithDifferentFiles = new MockFileSystem(new Dictionary<string, MockFileData>
    {
        { "C:\\folder1\\differentfile.txt", new MockFileData("different content") },
        { "C:\\folder2\\equalfile.txt", new MockFileData("equal content") }
    });
}
