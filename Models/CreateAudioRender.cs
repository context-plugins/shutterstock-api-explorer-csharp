using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Models.Enums;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Data required to create an audio render
/// </summary>
public record CreateAudioRender
{
    /// <summary>
    /// A user-specified file name suggestion; this file name becomes the filename property of the Content-Disposition header when the user downloads the rendered audio file
    /// </summary>
    [JsonPropertyName("filename")]
    public required string Filename { get; init; }

    /// <summary>
    /// File format, such as MP3 file, combined WAV file, or individual track WAV files
    /// </summary>
    [JsonPropertyName("preset")]
    public required Preset1 Preset { get; init; }

    /// <summary>
    /// A timeline object that represents either a request for music to be created or an entire music composition
    /// </summary>
    [JsonPropertyName("timeline")]
    public required AudioRenderTimeline Timeline { get; init; }
}
