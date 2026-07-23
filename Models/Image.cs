using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Information about an image
/// </summary>
public record Image
{
    /// <summary>
    /// Date that the image was added by the contributor
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
    /// Aspect ratio of the image in decimal format, such as 0.6667
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("aspect")]
    public double? Aspect { get; init; }

    /// <summary>
    /// Information about the assets that are part of an image
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("assets")]
    public ImageAssets? Assets { get; init; }

    /// <summary>
    /// Categories that this image is a part of
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
    /// Detailed description of the image
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// Indicates whether there are model releases for the image
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("has_model_release")]
    public bool? HasModelRelease { get; init; }

    /// <summary>
    /// Indicates whether there are property releases for the image
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("has_property_release")]
    public bool? HasPropertyRelease { get; init; }

    /// <summary>
    /// Image ID
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// Type of image
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("image_type")]
    public string? ImageType { get; init; }

    /// <summary>
    /// AI-powered insights about how the asset will perform for the objective and audience
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("insights")]
    public Insights2? Insights { get; init; }

    /// <summary>
    /// Whether or not this image contains adult content
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("is_adult")]
    public bool? IsAdult { get; init; }

    /// <summary>
    /// Whether or not this image is editorial content
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("is_editorial")]
    public bool? IsEditorial { get; init; }

    /// <summary>
    /// Whether or not this image is an illustration
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("is_illustration")]
    public bool? IsIllustration { get; init; }

    /// <summary>
    /// Keywords associated with the content of this image
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("keywords")]
    public IReadOnlyList<string>? Keywords { get; init; }

    /// <summary>
    /// Media type of this image, should always be "image"
    /// </summary>
    [JsonPropertyName("media_type")]
    public required string MediaType { get; init; }

    /// <summary>
    /// List of model releases
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("model_releases")]
    public IReadOnlyList<ModelRelease>? ModelReleases { get; init; }

    /// <summary>
    /// List of models
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("models")]
    public IReadOnlyList<Model>? Models { get; init; }

    /// <summary>
    /// List of all releases of this image
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("releases")]
    public IReadOnlyList<string>? Releases { get; init; }

    /// <summary>
    /// Link to image information page; included only for certain accounts
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("url")]
    public string? Url { get; init; }
}
