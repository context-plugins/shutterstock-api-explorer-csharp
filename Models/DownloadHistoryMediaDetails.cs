using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Information about the downloaded media
/// </summary>
public record DownloadHistoryMediaDetails
{
    /// <summary>
    /// Information about the format of a download
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("format")]
    public DownloadHistoryFormatDetails? Format { get; init; }

    /// <summary>
    /// ID of the download history media details
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }
}
