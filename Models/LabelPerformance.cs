using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

public record LabelPerformance
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("percentile_performance")]
    public double? PercentilePerformance { get; init; }
}
