using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Models.Enums;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Description of a license
/// </summary>
public record LicenseFormat
{
    /// <summary>
    /// Description of the license
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// Format or extension of the media, such as mpeg for videos or jpeg for images
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("format")]
    public string? Format { get; init; }

    /// <summary>
    /// Media type of the license
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("media_type")]
    public MediaType? MediaType { get; init; }

    /// <summary>
    /// Width of the media, in pixels, allowed by this license
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("min_resolution")]
    public int? MinResolution { get; init; }

    /// <summary>
    /// Keyword that details the size of the media, such as hd or sd for video, huge or vector for images
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("size")]
    public string? Size { get; init; }
}
