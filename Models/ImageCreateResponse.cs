using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Image upload information
/// </summary>
public record ImageCreateResponse
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }
}
