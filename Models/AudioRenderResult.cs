using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Models.Enums;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// The output of an audio render in WAV or MP3 format
/// </summary>
public record AudioRenderResult
{
    /// <summary>
    /// The time the render was submitted to the API
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("created_date")]
    public DateTimeOffset? CreatedDate { get; init; }

    /// <summary>
    /// The files associated with the render
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("files")]
    public IReadOnlyList<AudioRendersFilesList>? Files { get; init; }

    /// <summary>
    /// The alphanumeric ID of the simple render
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// The file format preset
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("preset")]
    public Preset? Preset { get; init; }

    /// <summary>
    /// The current progress of the render as a percentage
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("progress_percent")]
    public int? ProgressPercent { get; init; }

    /// <summary>
    /// A coarse progress indicator
    /// </summary>
    [JsonPropertyName("status")]
    public required Status Status { get; init; }

    /// <summary>
    /// A timeline object that represents either a request for music to be created or an entire music composition
    /// </summary>
    [JsonPropertyName("timeline")]
    public required AudioRenderTimeline Timeline { get; init; }

    /// <summary>
    /// The time that the audio output was uploaded
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("updated_date")]
    public DateTimeOffset? UpdatedDate { get; init; }
}
