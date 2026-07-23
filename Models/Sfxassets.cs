using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Files that are available as part of an sound effect asset
/// </summary>
public record Sfxassets
{
    /// <summary>
    /// Information about a file that is part of an sound effect asset
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("preview_mp3")]
    public SfxassetDetails? PreviewMp3 { get; init; }

    /// <summary>
    /// Information about a file that is part of an sound effect asset
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("waveform")]
    public SfxassetDetails? Waveform { get; init; }
}
