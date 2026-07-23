using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Subscription information
/// </summary>
public record Subscription
{
    /// <summary>
    /// An allotment of credits as part of a subscription
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("allotment")]
    public Allotment? Allotment { get; init; }

    /// <summary>
    /// Identifier for the type of assets associated with this subscription (images, videos, audio, editorial)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("asset_type")]
    public string? AssetType { get; init; }

    /// <summary>
    /// Description of the subscription
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// Date the subscription ends
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("expiration_time")]
    public DateTimeOffset? ExpirationTime { get; init; }

    /// <summary>
    /// List of formats that are licensable for the subscription
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("formats")]
    public IReadOnlyList<LicenseFormat>? Formats { get; init; }

    /// <summary>
    /// Unique internal identifier for the subscription
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// Internal identifier for the type of subscription
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("license")]
    public string? License { get; init; }

    /// <summary>
    /// Subscription metadata; different for each customer
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("metadata")]
    public object? Metadata { get; init; }

    /// <summary>
    /// Price
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("price_per_download")]
    public Price? PricePerDownload { get; init; }
}
