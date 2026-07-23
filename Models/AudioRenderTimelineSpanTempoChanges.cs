using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// An inflection point in a tempo curve; the API creates the overall tempo by using a linear interpolation of the time between each tempo change
/// </summary>
public record AudioRenderTimelineSpanTempoChanges
{
    /// <summary>
    /// The tempo, in beats per minute, active at this time
    /// </summary>
    [JsonPropertyName("tempo")]
    public required double Tempo { get; init; }

    /// <summary>
    /// The time, in seconds, at which the tempo exists
    /// </summary>
    [JsonPropertyName("time")]
    public required double Time { get; init; }
}
