using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

public record Shorts
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("url")]
    public string? Url { get; init; }
}
