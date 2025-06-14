namespace GbgGoodDeeds.Domain.Models;

/// <summary>
/// En god gärning som användare kan göra i Göteborg.
/// </summary>
public class GoodDeed
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string? Neighborhood { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public bool IsCompleted { get; set; } = false;
}
