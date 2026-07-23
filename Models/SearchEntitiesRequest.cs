using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Search entity request data
/// </summary>
public record SearchEntitiesRequest
{
    /// <summary>
    /// Plain text to extract keywords from
    /// </summary>
    [JsonPropertyName("text")]
    [StringLength(100000, MinimumLength = 1)]
    public required string Text { get; init; }
}
