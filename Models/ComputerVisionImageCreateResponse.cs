using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Asset upload information
/// </summary>
public record ComputerVisionImageCreateResponse
{
    [JsonPropertyName("upload_id")]
    public required string UploadId { get; init; }
}
