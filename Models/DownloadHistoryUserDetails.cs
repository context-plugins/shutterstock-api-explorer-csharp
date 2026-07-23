using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Information about a user
/// </summary>
public record DownloadHistoryUserDetails
{
    /// <summary>
    /// The name of the user who downloaded the item
    /// </summary>
    [JsonPropertyName("username")]
    public required string Username { get; init; }
}
