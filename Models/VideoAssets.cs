using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Video asset information
/// </summary>
public record VideoAssets
{
    /// <summary>
    /// Video asset information
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("4k")]
    public VideoSizeDetails? K4 { get; init; }

    /// <summary>
    /// Video asset information
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("hd")]
    public VideoSizeDetails? Hd { get; init; }

    /// <summary>
    /// URL object
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("preview_jpg")]
    public Url? PreviewJpg { get; init; }

    /// <summary>
    /// URL object
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("preview_mp4")]
    public Url? PreviewMp4 { get; init; }

    /// <summary>
    /// URL object
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("preview_webm")]
    public Url? PreviewWebm { get; init; }

    /// <summary>
    /// Video asset information
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("sd")]
    public VideoSizeDetails? Sd { get; init; }

    /// <summary>
    /// URL object
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("thumb_jpg")]
    public Url? ThumbJpg { get; init; }

    /// <summary>
    /// List of URLs
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("thumb_jpgs")]
    public Urls? ThumbJpgs { get; init; }

    /// <summary>
    /// URL object
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("thumb_mp4")]
    public Url? ThumbMp4 { get; init; }

    /// <summary>
    /// URL object
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("thumb_webm")]
    public Url? ThumbWebm { get; init; }

    /// <summary>
    /// Video asset information
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("web")]
    public VideoSizeDetails? Web { get; init; }
}
