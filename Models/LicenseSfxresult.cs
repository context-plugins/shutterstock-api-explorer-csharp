using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// The response to a licensing request for an sound effects
/// </summary>
public record LicenseSfxresult
{
    /// <summary>
    /// Number of credits that this licensing event used
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
    /// Error message, appears only if there was an error
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("error")]
    public string? Error { get; init; }

    /// <summary>
    /// ID of the license event
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("license_id")]
    public string? LicenseId { get; init; }

    /// <summary>
    /// Sound effects ID that was licensed
    /// </summary>
    [JsonPropertyName("sfx_id")]
    public required string SfxId { get; init; }
}
