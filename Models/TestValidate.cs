using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Validation results
/// </summary>
public record TestValidate
{
    /// <summary>
    /// Validation results
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("header")]
    public TestValidateHeader? Header { get; init; }

    /// <summary>
    /// Validation results
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("query")]
    public TestValidateQuery? Query { get; init; }
}
