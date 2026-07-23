using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Audio metadata
/// </summary>
public record Audio
{
    /// <summary>
    /// Date this track was added to the Shutterstock library
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
    /// Album metadata
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("album")]
    public Album? Album { get; init; }

    /// <summary>
    /// List of artists
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("artists")]
    public IReadOnlyList<Artist>? Artists { get; init; }

    /// <summary>
    /// Files that are available as part of an audio asset
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("assets")]
    public AudioAssets? Assets { get; init; }

    /// <summary>
    /// BPM (beats per minute) of this track
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("bpm")]
    public int? Bpm { get; init; }

    /// <summary>
    /// Information about a contributor
    /// </summary>
    [JsonPropertyName("contributor")]
    public required Contributor Contributor { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("deleted_time")]
    public DateTimeOffset? DeletedTime { get; init; }

    /// <summary>
    /// Description of this track
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// Duration of this track in seconds
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("duration")]
    public double? Duration { get; init; }

    /// <summary>
    /// List of all genres for this track
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("genres")]
    public IReadOnlyList<string>? Genres { get; init; }

    /// <summary>
    /// Shutterstock ID of this track
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// List of all instruments that appear in this track
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("instruments")]
    public IReadOnlyList<string>? Instruments { get; init; }

    /// <summary>
    /// Whether or not this track contains adult content
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("is_adult")]
    public bool? IsAdult { get; init; }

    /// <summary>
    /// Whether or not this track is purely instrumental (lacking lyrics)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("is_instrumental")]
    public bool? IsInstrumental { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isrc")]
    public string? Isrc { get; init; }

    /// <summary>
    /// List of all keywords for this track
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("keywords")]
    public IReadOnlyList<string>? Keywords { get; init; }

    /// <summary>
    /// Language of this track's lyrics
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("language")]
    public string? Language { get; init; }

    /// <summary>
    /// Lyrics of this track
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("lyrics")]
    public string? Lyrics { get; init; }

    /// <summary>
    /// Media type of this track; should always be "audio"
    /// </summary>
    [JsonPropertyName("media_type")]
    public required string MediaType { get; init; }

    /// <summary>
    /// List of all model releases for this track
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("model_releases")]
    public IReadOnlyList<ModelRelease>? ModelReleases { get; init; }

    /// <summary>
    /// List of all moods of this track
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("moods")]
    public IReadOnlyList<string>? Moods { get; init; }

    /// <summary>
    /// Time this track was published
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("published_time")]
    public DateTimeOffset? PublishedTime { get; init; }

    /// <summary>
    /// Recording version of this track
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("recording_version")]
    public string? RecordingVersion { get; init; }

    /// <summary>
    /// List of all releases of this track
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("releases")]
    public IReadOnlyList<string>? Releases { get; init; }

    /// <summary>
    /// List of all similar artists of this track
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("similar_artists")]
    public IReadOnlyList<Artist>? SimilarArtists { get; init; }

    /// <summary>
    /// Time this track was submitted
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("submitted_time")]
    public DateTimeOffset? SubmittedTime { get; init; }

    /// <summary>
    /// Title of this track
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("title")]
    public string? Title { get; init; }

    /// <summary>
    /// Time this track was last updated
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("updated_time")]
    public DateTimeOffset? UpdatedTime { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("url")]
    public string? Url { get; init; }

    /// <summary>
    /// Vocal description of this track
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("vocal_description")]
    public string? VocalDescription { get; init; }
}
