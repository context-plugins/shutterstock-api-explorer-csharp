using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Audio render data
/// </summary>
public record AudioRendersListResults
{
    /// <summary>
    /// Audio render results
    /// </summary>
    [JsonPropertyName("audio_renders")]
    public required IReadOnlyList<AudioRenderResult> AudioRenders { get; init; }
}
