using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Models.Enums;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// The key signature active at the beginning of the region
/// </summary>
public record Key
{
    /// <summary>
    /// A text representation of the accidental; if this field is specified, the tonic_note field should also be specified
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("tonic_accidental")]
    public TonicAccidental? TonicAccidental { get; init; }

    /// <summary>
    /// A text representation of the musical note; if this field is specified, the tonic_accidental field should also be specified
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("tonic_note")]
    public TonicNote? TonicNote { get; init; }

    /// <summary>
    /// The scale quality; if this field is not specified, the API selects the quality automatically
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("tonic_quality")]
    public TonicQuality? TonicQuality { get; init; }
}
