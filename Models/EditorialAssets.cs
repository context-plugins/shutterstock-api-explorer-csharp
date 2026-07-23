using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Asset information, including size and thumbnail URLs
/// </summary>
public record EditorialAssets
{
    /// <summary>
    /// Image size information
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("medium_jpg")]
    public ImageSizeDetails? MediumJpg { get; init; }

    /// <summary>
    /// Image size information
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("original")]
    public ImageSizeDetails? Original { get; init; }

    /// <summary>
    /// Image size information
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("small_jpg")]
    public ImageSizeDetails? SmallJpg { get; init; }

    /// <summary>
    /// Image thumbnail information
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("thumb_170")]
    public Thumbnail? Thumb170 { get; init; }

    /// <summary>
    /// Image thumbnail information
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("thumb_220")]
    public Thumbnail? Thumb220 { get; init; }

    /// <summary>
    /// Image thumbnail information
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("watermark_1500")]
    public Thumbnail? Watermark1500 { get; init; }

    /// <summary>
    /// Image thumbnail information
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("watermark_450")]
    public Thumbnail? Watermark450 { get; init; }
}
