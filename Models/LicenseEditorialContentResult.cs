using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// The response to a licensing request for editorial content
/// </summary>
public record LicenseEditorialContentResult
{
    /// <summary>
    /// For pre-paid plans, how many credits were used for the item license
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("allotment_charge")]
    public int? AllotmentCharge { get; init; }

    /// <summary>
    /// URL object
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("download")]
    public Url? Download { get; init; }

    /// <summary>
    /// Editorial ID
    /// </summary>
    [JsonPropertyName("editorial_id")]
    public required string EditorialId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("error")]
    public string? Error { get; init; }
}
