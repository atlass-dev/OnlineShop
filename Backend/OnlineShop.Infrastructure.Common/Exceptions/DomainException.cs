using System.Runtime.Serialization;

namespace OnlineShop.Infrastructure.Common.Exceptions;

/// <summary>
/// The exception that occurs in domain part of application.
/// </summary>
[Serializable]
public class DomainException : Exception
{
    /// <summary>
    /// Optional description code for this exception.
    /// </summary>
    public string Code { get; protected set; } = string.Empty;

    /// <summary>
    /// Constructor.
    /// </summary>
    public DomainException()
    {
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="message">Message.</param>
    public DomainException(string message) : base(message)
    {
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="message">Message.</param>
    /// <param name="innerException">Inner exception.</param>
    public DomainException(string message, Exception innerException) :
        base(message, innerException)
    {
    }

    /// <inheritdoc />
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
        info.AddValue("code", Code);
    }
}
