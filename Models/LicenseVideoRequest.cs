using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// List of videos to license
/// </summary>
public record LicenseVideoRequest
{
    /// <summary>
    /// Videos to license
    /// </summary>
    [JsonPropertyName("videos")]
    [MaxLength(50)]
    public required IReadOnlyList<LicenseVideo> Videos { get; init; }
}
