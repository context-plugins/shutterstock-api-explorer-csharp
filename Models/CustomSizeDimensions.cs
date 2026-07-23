using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Validation.Attributes;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// A custom height or a custom width to resize the image to, but not both (experimental)
/// </summary>
public record CustomSizeDimensions
{
    /// <summary>
    /// Custom height to resize the image to
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("height")]
    [Minimum(100)]
    public int? Height { get; init; }

    /// <summary>
    /// Custom width to resize the image to
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("width")]
    [Minimum(100)]
    public int? Width { get; init; }
}
