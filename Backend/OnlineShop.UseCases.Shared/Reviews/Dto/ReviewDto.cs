using OnlineShop.Domain.Entities;

namespace OnlineShop.UseCases.Shared.Reviews.Dto;

/// <inheritdoc cref="Review"/>
public record ReviewDto
{
    /// <summary>
    /// Review's id.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Product's id.
    /// </summary>
    public int ProductId { get; init; }

    /// <summary>
    /// Review's rating.
    /// </summary>
    public int Rating { get; init; }

    /// <summary>
    /// Review's description.
    /// </summary>
    public string Description { get; init; }

    /// <summary>
    /// Reviewer's id.
    /// </summary>
    public int ReviewerId { get; init; }
}
