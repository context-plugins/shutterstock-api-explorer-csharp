using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Information about the assets that are part of an image
/// </summary>
public record ImageAssets
{
    /// <summary>
    /// Image size information
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("huge_jpg")]
    public ImageSizeDetails? HugeJpg { get; init; }

    /// <summary>
    /// Image thumbnail information
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("huge_thumb")]
    public Thumbnail? HugeThumb { get; init; }

    /// <summary>
    /// Image thumbnail information
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("large_thumb")]
    public Thumbnail? LargeThumb { get; init; }

    /// <summary>
    /// Image size information
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("medium_jpg")]
    public ImageSizeDetails? MediumJpg { get; init; }

    /// <summary>
    /// Image thumbnail information
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("preview")]
    public Thumbnail? Preview { get; init; }

    /// <summary>
    /// Image thumbnail information
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("preview_1000")]
    public Thumbnail? Preview1000 { get; init; }

    /// <summary>
    /// Image thumbnail information
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("preview_1500")]
    public Thumbnail? Preview1500 { get; init; }

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
    [JsonPropertyName("small_thumb")]
    public Thumbnail? SmallThumb { get; init; }

    /// <summary>
    /// Image size information
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("supersize_jpg")]
    public ImageSizeDetails? SupersizeJpg { get; init; }

    /// <summary>
    /// Image size information
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("vector_eps")]
    public ImageSizeDetails? VectorEps { get; init; }
}
