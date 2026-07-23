using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// The response to a licensing request for a video
/// </summary>
public record LicenseVideoResult
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
    /// Potential error that occurred during licensing
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
    /// Price
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("price")]
    public Price? Price { get; init; }

    /// <summary>
    /// ID of the video that was licensed
    /// </summary>
    [JsonPropertyName("video_id")]
    public required string VideoId { get; init; }
}
