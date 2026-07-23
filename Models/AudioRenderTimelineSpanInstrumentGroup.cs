using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// An instrument and the status objects that specify when that instrument plays
/// </summary>
public record AudioRenderTimelineSpanInstrumentGroup
{
    /// <summary>
    /// The instrument ID
    /// </summary>
    [JsonPropertyName("instrument_group")]
    public required string InstrumentGroup { get; init; }

    /// <summary>
    /// An array of status objects
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("statuses")]
    public IReadOnlyList<AudioRenderTimelineSpanInstrumentGroupStatus>? Statuses { get; init; }
}
