using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// AI-powered insights about an asset, based on the specified audience and objective
/// </summary>
public record Insights
{
    /// <summary>
    /// How effective the AI thinks an asset in the category is for the specified audience and objective, expressed as a percentile compared to other images
    /// </summary>
    [JsonPropertyName("label_performance")]
    public required IReadOnlyList<LabelPerformance> LabelPerformance { get; init; }
}
