using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Request to upload an image
/// </summary>
public record ImageCreateRequest
{
    /// <summary>
    /// A Base 64 encoded jpeg or png; images can be no larger than 10mb and can be no larger than 10,000 pixels in width or height
    /// </summary>
    [JsonPropertyName("base64_image")]
    public required string Base64Image { get; init; }
}
