using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// License sounds effect asset request body
/// </summary>
public record LicenseSfxrequest
{
    /// <summary>
    /// Sound effects to license for
    /// </summary>
    [JsonPropertyName("sound_effects")]
    public required IReadOnlyList<LicenseSfx> SoundEffects { get; init; }
}
