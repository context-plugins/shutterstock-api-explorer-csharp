using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Image license request data
/// </summary>
public record LicenseImageRequest
{
    /// <summary>
    /// Images to create licenses for
    /// </summary>
    [JsonPropertyName("images")]
    [MaxLength(50)]
    public required IReadOnlyList<Image1> Images { get; init; }
}
