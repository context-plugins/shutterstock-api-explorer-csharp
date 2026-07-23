using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// SFX metadata
/// </summary>
public record Sfx
{
    /// <summary>
    /// Date this sound effect was added to the Shutterstock library
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
    /// Artist of the sound effect
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("artist")]
    public string? Artist { get; init; }

    /// <summary>
    /// Files that are available as part of an sound effect asset
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("assets")]
    public Sfxassets? Assets { get; init; }

    /// <summary>
    /// Information about a contributor
    /// </summary>
    [JsonPropertyName("contributor")]
    public required Contributor Contributor { get; init; }

    /// <summary>
    /// Description of this sound effect
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// Duration of this sound effect in seconds
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("duration")]
    public double? Duration { get; init; }

    /// <summary>
    /// Shutterstock ID of this sound effect
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// List of all keywords for this sound effect
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("keywords")]
    public IReadOnlyList<string>? Keywords { get; init; }

    /// <summary>
    /// Media type of this track; should always be "sfx"
    /// </summary>
    [JsonPropertyName("media_type")]
    public required string MediaType { get; init; }

    /// <summary>
    /// List of all releases of this sound effect
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("releases")]
    public IReadOnlyList<string>? Releases { get; init; }

    /// <summary>
    /// Title of this sound effect
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("title")]
    public string? Title { get; init; }

    /// <summary>
    /// Time this sound effect was last updated
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("updated_time")]
    public DateTimeOffset? UpdatedTime { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("url")]
    public string? Url { get; init; }
}
