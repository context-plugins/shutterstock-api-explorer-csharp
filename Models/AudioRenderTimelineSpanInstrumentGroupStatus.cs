using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Models.Enums;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// The status of an instrument at a specific beat
/// </summary>
public record AudioRenderTimelineSpanInstrumentGroupStatus
{
    /// <summary>
    /// The beat, relative to the span, at which the status begins
    /// </summary>
    [JsonPropertyName("beat")]
    public required double Beat { get; init; }

    /// <summary>
    /// Whether the instrument is playing or not
    /// </summary>
    [JsonPropertyName("status")]
    public required Status1 Status { get; init; }
}
