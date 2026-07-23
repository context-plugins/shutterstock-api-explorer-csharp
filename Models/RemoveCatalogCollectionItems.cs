using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

public record RemoveCatalogCollectionItems
{
    [JsonPropertyName("items")]
    [MinLength(1)]
    [MaxLength(50)]
    public required IReadOnlyList<RemoveCatalogCollectionItem> Items { get; init; }
}
