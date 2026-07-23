using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Validation results
/// </summary>
public record TestValidateHeader
{
    /// <summary>
    /// User agent to expect in the response
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("user-agent")]
    public string? UserAgent { get; init; }
}
