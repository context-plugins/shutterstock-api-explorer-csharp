using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Links for Shorts, Loops and Stems previews
/// </summary>
public record ShortsLoopsStems
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("loops")]
    public IReadOnlyDictionary<string, Loops>? Loops { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shorts")]
    public IReadOnlyDictionary<string, Shorts>? Shorts { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("stems")]
    public IReadOnlyDictionary<string, Stems>? Stems { get; init; }
}
