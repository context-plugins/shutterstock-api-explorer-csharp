using System;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Information about a downloaded media item. Applicable for all media types, only one of 'audio', 'image' or 'video' will be in a single DownloadHistory object
/// </summary>
public record DownloadHistory
{
    /// <summary>
    /// Information about the downloaded media
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("audio")]
    public DownloadHistoryMediaDetails? Audio { get; init; }

    /// <summary>
    /// Date the media was downloaded the first time
    /// </summary>
    [JsonPropertyName("download_time")]
    public required DateTimeOffset DownloadTime { get; init; }

    /// <summary>
    /// ID of the download
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// Information about the downloaded media
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("image")]
    public DownloadHistoryMediaDetails? Image { get; init; }

    /// <summary>
    /// Specifies if the media is downloadable via its respective downloads endpoint
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("is_downloadable")]
    public bool? IsDownloadable { get; init; }

    /// <summary>
    /// The name of the license of this download
    /// </summary>
    [JsonPropertyName("license")]
    public required string License { get; init; }

    /// <summary>
    /// The metadata that was passed in the original licensing request
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("metadata")]
    public object? Metadata { get; init; }

    /// <summary>
    /// Pricing information for revenue-sharing transactions
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("revshare")]
    public DownloadHistoryRevshareDetails? Revshare { get; init; }

    /// <summary>
    /// ID of the subscription used to perform this download
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("subscription_id")]
    public string? SubscriptionId { get; init; }

    /// <summary>
    /// Information about a user
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("user")]
    public DownloadHistoryUserDetails? User { get; init; }

    /// <summary>
    /// Information about the downloaded media
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("video")]
    public DownloadHistoryMediaDetails? Video { get; init; }
}
