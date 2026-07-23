using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Models.Enums;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Data required to license an image
/// </summary>
public record LicenseImageVector
{
    /// <summary>
    /// Cookie object
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("auth_cookie")]
    public Cookie? AuthCookie { get; init; }

    /// <summary>
    /// Set to true to acknowledge the editorial agreement
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("editorial_acknowledgement")]
    public bool? EditorialAcknowledgement { get; init; }

    /// <summary>
    /// (Deprecated) Image format to download
    /// </summary>
    [JsonPropertyName("format")]
    public Format1? Format { get; init; } = Format1.Eps;

    /// <summary>
    /// Image ID
    /// </summary>
    [JsonPropertyName("image_id")]
    public required string ImageId { get; init; }

    /// <summary>
    /// Additional information for license requests for enterprise accounts and API subscriptions, 4 fields maximum; which fields are required is set by the account holder
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("metadata")]
    public object? Metadata { get; init; }

    /// <summary>
    /// For revenue-sharing transactions, the final cost to the end customer as a floating-point number in the transaction currency, such as 12.34
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("price")]
    public double? Price { get; init; }

    /// <summary>
    /// ID of the search that led to this licensing transaction
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
    /// Image size to download
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("size")]
    public Size3? Size { get; init; }

    /// <summary>
    /// ID of the subscription to use for the download.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("subscription_id")]
    public string? SubscriptionId { get; init; }

    /// <summary>
    /// (Deprecated)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("verification_code")]
    public string? VerificationCode { get; init; }
}
