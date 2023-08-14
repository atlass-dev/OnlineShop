namespace OnlineShop.Infrastructure.Common.Exceptions;

/// <summary>
/// Thrown in case if object wasn't found.
/// </summary>
public class NotFoundException : DomainException
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public NotFoundException()
    {
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="message">Message.</param>
    public NotFoundException(string message) : base(message)
    {
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="message">Message.</param>
    /// <param name="innerException">Inner exception.</param>
    public NotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
