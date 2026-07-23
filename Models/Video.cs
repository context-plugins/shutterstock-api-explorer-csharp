using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Information about a video
/// </summary>
public record Video
{
    /// <summary>
    /// Date this video was added to the Shutterstock library
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("added_date")]
    public DateTimeOffset? AddedDate { get; init; }

    /// <summary>
    /// Affiliate referral link; appears only for registered affiliate partners
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("affiliate_url")]
    public string? AffiliateUrl { get; init; }

    /// <summary>
    /// Aspect ratio of this video in decimal format, such as 0.6667
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("aspect")]
    public double? Aspect { get; init; }

    /// <summary>
    /// Aspect ratio of the video as a ratio, such as 16:9
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("aspect_ratio")]
    public string? AspectRatio { get; init; }

    /// <summary>
    /// Video asset information
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("assets")]
    public VideoAssets? Assets { get; init; }

    /// <summary>
    /// List of categories
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("categories")]
    public IReadOnlyList<Category>? Categories { get; init; }

    /// <summary>
    /// Information about a contributor
    /// </summary>
    [JsonPropertyName("contributor")]
    public required Contributor Contributor { get; init; }

    /// <summary>
    /// Description of this video
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// Duration of this video, in seconds
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("duration")]
    public double? Duration { get; init; }

    /// <summary>
    /// Whether or not this video has been released for use by the model appearing in it
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("has_model_release")]
    public bool? HasModelRelease { get; init; }

    /// <summary>
    /// Whether or not this video has received a release to show the landmark or property appearing in it
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("has_property_release")]
    public bool? HasPropertyRelease { get; init; }

    /// <summary>
    /// ID of the video
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// Whether or not this video contains adult content
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("is_adult")]
    public bool? IsAdult { get; init; }

    /// <summary>
    /// Whether or not this video is editorial content
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("is_editorial")]
    public bool? IsEditorial { get; init; }

    /// <summary>
    /// Keywords associated with the content of this video
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("keywords")]
    public IReadOnlyList<string>? Keywords { get; init; }

    /// <summary>
    /// Media type of this video, should always be "video"
    /// </summary>
    [JsonPropertyName("media_type")]
    public required string MediaType { get; init; }

    /// <summary>
    /// List of models in this video
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("models")]
    public IReadOnlyList<Model>? Models { get; init; }

    /// <summary>
    /// Link to video information page; included only for certain accounts
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("url")]
    public string? Url { get; init; }
}
