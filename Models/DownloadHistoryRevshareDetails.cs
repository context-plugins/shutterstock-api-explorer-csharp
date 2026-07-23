using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Pricing information for revenue-sharing transactions
/// </summary>
public record DownloadHistoryRevshareDetails
{
    /// <summary>
    /// The amount charged for the license
    /// </summary>
    [JsonPropertyName("purchase_amount")]
    public required string PurchaseAmount { get; init; }

    /// <summary>
    /// The currency the amount was charged in
    /// </summary>
    [JsonPropertyName("purchase_currency")]
    public required string PurchaseCurrency { get; init; }
}
