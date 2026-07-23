using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// List of instruments
/// </summary>
public record InstrumentList
{
    /// <summary>
    /// List of instruments
    /// </summary>
    [JsonPropertyName("data")]
    public required IReadOnlyList<string> Data { get; init; }
}
