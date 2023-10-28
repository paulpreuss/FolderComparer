using FluentAssertions;
using NUnit.Framework;
using Preuss.FolderComparer.Comparer.Abstractions.DataClasses;
using Preuss.FolderComparer.Comparer.Abstractions.Exceptions;
using Preuss.FolderComparer.Comparer.Repositories;

namespace Preuss.FolderComparer.Comparer.Tests.Repositories;

public class ComparableFileRepositoryTests
{
    [Test]
    public void GetFiles_WithEmptyDirectory_ShouldReturnEmptyList()
    {
        var repository = new ComparableFileRepository(Constants.FileSystemWithNoFiles);
        var expected = new List<ComparableFile>();

        var actual = repository.GetFiles("C:\\");

        actual.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void GetFiles_WithExistingFiles_ShouldReturnComparableFiles()
    {
        var repository = new ComparableFileRepository(Constants.FileSystemWithFiles);
        var expected = new List<ComparableFile>
        {
            new ()
            {
                 Id = string.Empty,
                 Hash = "437B930DB84B8079C2DD804A71936B5F",
                 Path = "C:\\test.txt"
            }
        };

        var actual = repository.GetFiles("C:\\");

        actual.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void GetFiles_WithFilePath_ShouldThrowComparerDataAccessException()
    {
        var repository = new ComparableFileRepository(Constants.FileSystemWithFiles);

        Action act = () => repository.GetFiles("C:\\test.txt");

        act.Should().Throw<ComparerDataAccessException>().WithMessage("Could read files of C:\\test.txt. Probably it is a file path. Please enter a valid folder path.");
    }

    [Test]
    [TestCase("")]
    [TestCase("    ")]
    public void GetFiles_WithEmptyPath_ShouldThrowArgumentException(string path)
    {
        var repository = new ComparableFileRepository(Constants.FileSystemWithFiles);

        Action act = () => repository.GetFiles(path);

        act.Should().Throw<ArgumentException>().WithMessage($"{path} is not a valid path.");
    }
}
