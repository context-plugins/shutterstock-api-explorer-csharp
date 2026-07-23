using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Models.Enums;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// A period of music or silence, measured in beats
/// </summary>
public record AudioRenderTimelineSpanRegion
{
    /// <summary>
    /// The beat, relative to the span, at which the region object's music begins
    /// </summary>
    [JsonPropertyName("beat")]
    public required int Beat { get; init; }

    /// <summary>
    /// The descriptor ID needed to compose the music
    /// </summary>
    [JsonPropertyName("descriptor")]
    public required string Descriptor { get; init; }

    /// <summary>
    /// A high-level description of how a region ends
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("end_type")]
    public EndType? EndType { get; init; }

    /// <summary>
    /// An identifier which must be unique within the parent span
    /// </summary>
    [JsonPropertyName("id")]
    public required double Id { get; init; }

    /// <summary>
    /// The key signature active at the beginning of the region
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("key")]
    public Key? Key { get; init; }

    /// <summary>
    /// The type of region
    /// </summary>
    [JsonPropertyName("region")]
    public required Region Region { get; init; }
}
