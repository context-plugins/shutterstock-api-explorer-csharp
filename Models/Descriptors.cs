using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Information about a descriptor
/// </summary>
public record Descriptors
{
    /// <summary>
    /// The average ratio of the length of the music to the time it takes to render; for example, a render speed of 3.0 generates 30 seconds of music in about 10 seconds
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("average_render_speed")]
    public double? AverageRenderSpeed { get; init; }

    /// <summary>
    /// The bands that are available to use this descriptor
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("bands")]
    public IReadOnlyList<Bands>? Bands { get; init; }

    /// <summary>
    /// The ID of the descriptor
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// The instruments that can play with this descriptor
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("instruments")]
    public IReadOnlyList<Instruments>? Instruments { get; init; }

    /// <summary>
    /// The maximum beats per minute that the descriptor is intended to be used with
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("max_tempo")]
    public double? MaxTempo { get; init; }

    /// <summary>
    /// The minimum beats per minute that the descriptor is intended to be used with
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("min_tempo")]
    public double? MinTempo { get; init; }

    /// <summary>
    /// The name of the descriptor
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Preview of the descriptor
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("previews")]
    public IReadOnlyList<Preview>? Previews { get; init; }

    /// <summary>
    /// Tags that describe the descriptor
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("tags")]
    public IReadOnlyList<string>? Tags { get; init; }
}
