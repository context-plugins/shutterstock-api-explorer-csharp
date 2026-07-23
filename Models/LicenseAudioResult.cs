using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// The response to a licensing request for an audio track
/// </summary>
public record LicenseAudioResult
{
    /// <summary>
    /// Number of credits that this licensing event used
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("allotment_charge")]
    public double? AllotmentCharge { get; init; }

    /// <summary>
    /// ID of the track that was licensed
    /// </summary>
    [JsonPropertyName("audio_id")]
    public required string AudioId { get; init; }

    /// <summary>
    /// Audio License URL object
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("download")]
    public AudioUrl? Download { get; init; }

    /// <summary>
    /// Error information if applicable
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
}
