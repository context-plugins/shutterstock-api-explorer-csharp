using System.Collections.Generic;
using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Models.Enums;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// The beginning of a non-overlapping period of absolute time
/// </summary>
public record AudioRenderTimelineSpan
{
    /// <summary>
    /// An identifier which must be unique within the parent span
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("id")]
    public double? Id { get; init; }

    /// <summary>
    /// An array of instrument_group objects that are used in this span
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("instrument_groups")]
    public IReadOnlyList<AudioRenderTimelineSpanInstrumentGroup>? InstrumentGroups { get; init; }

    /// <summary>
    /// An array of region objects within the span
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("regions")]
    public IReadOnlyList<AudioRenderTimelineSpanRegion>? Regions { get; init; }

    /// <summary>
    /// Type of span; metered spans represent a pariod of time with music, and unmetered spans denote the end of the prior metered span
    /// </summary>
    [JsonPropertyName("span_type")]
    public required SpanType SpanType { get; init; }

    /// <summary>
    /// The tempo, in beats per minute, at the start of the span; if not provided, the API selects a random tempo
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("tempo")]
    public int? Tempo { get; init; }

    /// <summary>
    /// Two or more inflection points in a tempo curve; the API creates a smoothly changing tempo by using a linear interpolation of the time between each tempo change
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("tempo_changes")]
    public IReadOnlyList<AudioRenderTimelineSpanTempoChanges>? TempoChanges { get; init; }

    /// <summary>
    /// The absolute time, in seconds, at which the span starts
    /// </summary>
    [JsonPropertyName("time")]
    public required int Time { get; init; }
}
