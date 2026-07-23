using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// List of editorial categories
/// </summary>
public record EditorialCategoryResults
{
    /// <summary>
    /// List of editorial categories
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("data")]
    public IReadOnlyList<EditorialCategory>? Data { get; init; }
}
