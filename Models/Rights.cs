using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

public record Rights
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("countries")]
    public string? Countries { get; init; }
}
