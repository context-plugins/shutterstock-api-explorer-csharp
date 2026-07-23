using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Models.Enums;

namespace ShutterstockApiExplorer.Models;

public record LicenseSfx
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("audio_layout")]
    public AudioLayout? AudioLayout { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("format")]
    public Format3? Format { get; init; }

    /// <summary>
    /// ID of the search that led to this licensing event
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("search_id")]
    public string? SearchId { get; init; }

    /// <summary>
    /// ID of the sounds effect being licensed
    /// </summary>
    [JsonPropertyName("sfx_id")]
    public required string SfxId { get; init; }

    /// <summary>
    /// ID of the subscription to use for the download.
    /// </summary>
    [JsonPropertyName("subscription_id")]
    public required string SubscriptionId { get; init; }
}
