using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// The response to a licensing request for an image
/// </summary>
public record LicenseImageResult
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
    /// Image ID that was licensed
    /// </summary>
    [JsonPropertyName("image_id")]
    public required string ImageId { get; init; }

    /// <summary>
    /// ID of the license event
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("license_id")]
    public string? LicenseId { get; init; }

    /// <summary>
    /// Price
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("price")]
    public Price? Price { get; init; }
}
