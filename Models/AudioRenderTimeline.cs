using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// A timeline object that represents either a request for music to be created or an entire music composition
/// </summary>
public record AudioRenderTimeline
{
    /// <summary>
    /// A span object that represents the beginning of a period of absolute time
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("spans")]
    public IReadOnlyList<AudioRenderTimelineSpan>? Spans { get; init; }
}
