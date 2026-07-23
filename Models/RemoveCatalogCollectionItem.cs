using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

public record RemoveCatalogCollectionItem
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }
}
