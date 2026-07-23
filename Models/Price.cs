using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Price
/// </summary>
public record Price
{
    /// <summary>
    /// Floating-point amount of the calculated rev-share price in the currency local_currency
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("local_amount")]
    public double? LocalAmount { get; init; }

    /// <summary>
    /// Currency of the rev-share price that was calculated
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("local_currency")]
    public string? LocalCurrency { get; init; }
}
