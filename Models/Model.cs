using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Information about a human model or property that appears in media; used to search for assets that this model is in
/// </summary>
public record Model
{
    /// <summary>
    /// ID of the model
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }
}
