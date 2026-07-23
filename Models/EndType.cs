using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Models.Enums;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// A high-level description of how a region ends
/// </summary>
public record EndType
{
    /// <summary>
    /// The beat, relative to the start of the active region, at which the end_type begins; in other words, the ending starts on this beat of the region
    /// </summary>
    [JsonPropertyName("beat")]
    public required double Beat { get; init; }

    /// <summary>
    /// The type of event
    /// </summary>
    [JsonPropertyName("event")]
    public required Event Event { get; init; }

    /// <summary>
    /// The specific action to perform; if the event type is "ending" then this must be "ringout" and if event type is "transition" this must be "cut"
    /// </summary>
    [JsonPropertyName("type")]
    public required TypeModel Type { get; init; }
}
