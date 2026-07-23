using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Asset information, including size and thumbnail URLs
/// </summary>
public record EditorialVideoAssets
{
    /// <summary>
    /// Video asset information
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("original")]
    public VideoSizeDetails? Original { get; init; }

    /// <summary>
    /// Video preview information
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("preview_mp4")]
    public VideoPreviewUrl? PreviewMp4 { get; init; }

    /// <summary>
    /// Video preview information
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("preview_webm")]
    public VideoPreviewUrl? PreviewWebm { get; init; }

    /// <summary>
    /// Video preview information
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("thumb_jpg")]
    public VideoPreviewUrl? ThumbJpg { get; init; }
}
