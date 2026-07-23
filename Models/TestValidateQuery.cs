using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Validation results
/// </summary>
public record TestValidateQuery
{
    /// <summary>
    /// Integer ID that was passed in the request
    /// </summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>
    /// List of tags that were passed in the request
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("tag")]
    public IReadOnlyList<string>? Tag { get; init; }
}
