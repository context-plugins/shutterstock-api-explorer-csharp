using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

public record Loops
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("url")]
    public string? Url { get; init; }
}
