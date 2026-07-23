using System.Collections.Generic;
using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Models.Enums;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// License editorial video content request
/// </summary>
public record LicenseEditorialVideoContentRequest
{
    /// <summary>
    /// A valid ISO 3166-1 Alpha-2 or ISO 3166-1 Alpha-3 code.
    /// </summary>
    [JsonPropertyName("country")]
    public required IsocountryCode Country { get; init; }

    /// <summary>
    /// Editorial content to license
    /// </summary>
    [JsonPropertyName("editorial")]
    public required IReadOnlyList<LicenseEditorialVideoContent> Editorial { get; init; }
}
