using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Audio license request data
/// </summary>
public record LicenseAudioRequest
{
    /// <summary>
    /// List of audio tracks to license
    /// </summary>
    [JsonPropertyName("audio")]
    [MaxLength(50)]
    public required IReadOnlyList<LicenseAudio> Audio { get; init; }
}
