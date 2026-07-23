using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Models.Enums;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Data required to license a video
/// </summary>
public record LicenseVideo
{
    /// <summary>
    /// Cookie object
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("auth_cookie")]
    public Cookie? AuthCookie { get; init; }

    /// <summary>
    /// Whether or not this item is editorial content
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("editorial_acknowledgement")]
    public bool? EditorialAcknowledgement { get; init; }

    /// <summary>
    /// Additional information for license requests for enterprise accounts and API subscriptions, 4 fields maximum; which fields are required is set by the account holder
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("metadata")]
    public object? Metadata { get; init; }

    /// <summary>
    /// Retail price amount as a floating-point number in the transaction currency, such as 12.34; only for rev-share partners
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("price")]
    public double? Price { get; init; }

    /// <summary>
    /// ID of the search that led to this licensing event
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("search_id")]
    public string? SearchId { get; init; }

    /// <summary>
    /// (Deprecated)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("show_modal")]
    public bool? ShowModal { get; init; }

    /// <summary>
    /// Size of the video being licensed
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("size")]
    public Size5? Size { get; init; }

    /// <summary>
    /// ID of the subscription used for this license
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("subscription_id")]
    public string? SubscriptionId { get; init; }

    /// <summary>
    /// ID of the video being licensed
    /// </summary>
    [JsonPropertyName("video_id")]
    public required string VideoId { get; init; }
}
