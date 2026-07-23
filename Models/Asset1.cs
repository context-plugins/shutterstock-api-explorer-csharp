using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

public record Asset1
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("type")]
    public required string Type { get; init; }
}
