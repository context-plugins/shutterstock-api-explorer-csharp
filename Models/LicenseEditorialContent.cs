using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Models.Enums;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Individual editorial content to license
/// </summary>
public record LicenseEditorialContent
{
    /// <summary>
    /// Editorial ID
    /// </summary>
    [JsonPropertyName("editorial_id")]
    public required string EditorialId { get; init; }

    /// <summary>
    /// License agreement to use for licensing
    /// </summary>
    [JsonPropertyName("license")]
    public required string License { get; init; }

    /// <summary>
    /// Additional information for license requests for enterprise accounts and API subscriptions, 4 fields maximum; which fields are required is set by the account holder
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("metadata")]
    public object? Metadata { get; init; }

    /// <summary>
    /// Asset size to download
    /// </summary>
    [JsonPropertyName("size")]
    public Size? Size { get; init; } = Size.Original;
}
