using System.Runtime.Serialization;

namespace Preuss.FolderComparer.DataAccess.Abstractions.Exceptions;

[Serializable]
public class ComparerDataAccessException : Exception
{
    public ComparerDataAccessException()
    {
    }

    public ComparerDataAccessException(string? message) : base(message)
    {
    }

    public ComparerDataAccessException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected ComparerDataAccessException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
