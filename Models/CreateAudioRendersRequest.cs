using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Render request data
/// </summary>
public record CreateAudioRendersRequest
{
    /// <summary>
    /// Parameters to create computer audio renders
    /// </summary>
    [JsonPropertyName("audio_renders")]
    public required IReadOnlyList<CreateAudioRender> AudioRenders { get; init; }
}
