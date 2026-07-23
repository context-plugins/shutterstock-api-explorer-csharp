using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Files that are available as part of an audio asset
/// </summary>
public record AudioAssets
{
    /// <summary>
    /// Information about a file that is part of an audio asset
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("album_art")]
    public AudioAssetDetails? AlbumArt { get; init; }

    /// <summary>
    /// Information about a file that is part of an audio asset
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("clean_audio")]
    public AudioAssetDetails? CleanAudio { get; init; }

    /// <summary>
    /// Information about a file that is part of an audio asset
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("original_audio")]
    public AudioAssetDetails? OriginalAudio { get; init; }

    /// <summary>
    /// Information about a file that is part of an audio asset
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("preview_mp3")]
    public AudioAssetDetails? PreviewMp3 { get; init; }

    /// <summary>
    /// Information about a file that is part of an audio asset
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("preview_ogg")]
    public AudioAssetDetails? PreviewOgg { get; init; }

    /// <summary>
    /// Links for Shorts, Loops and Stems previews
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shorts_loops_stems")]
    public ShortsLoopsStems? ShortsLoopsStems { get; init; }

    /// <summary>
    /// Information about a file that is part of an audio asset
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("waveform")]
    public AudioAssetDetails? Waveform { get; init; }
}
