using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Models.Enums;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// An audio track in a licensing request
/// </summary>
public record LicenseAudio
{
    /// <summary>
    /// ID of the track being licensed
    /// </summary>
    [JsonPropertyName("audio_id")]
    public required string AudioId { get; init; }

    /// <summary>
    /// Type of license
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("license")]
    public License1? License { get; init; }

    /// <summary>
    /// ID of the search that led to this licensing event
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("search_id")]
    public string? SearchId { get; init; }
}
