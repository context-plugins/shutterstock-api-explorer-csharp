using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Cookie object
/// </summary>
public record Cookie
{
    /// <summary>
    /// The name of the cookie
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// The value of the cookie
    /// </summary>
    [JsonPropertyName("value")]
    public required string Value { get; init; }
}
