using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Models.Enums;

namespace ShutterstockApiExplorer.Models;

public record CreateCatalogCollection
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("items")]
    [MaxLength(50)]
    public IReadOnlyList<CreateCatalogCollectionItem>? Items { get; init; }

    [JsonPropertyName("name")]
    [StringLength(100000, MinimumLength = 1)]
    public required string Name { get; init; }

    [JsonPropertyName("visibility")]
    public Visibility? Visibility { get; init; } = Visibility.Private;
}
