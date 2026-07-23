using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

public record CreateCatalogCollectionItem
{
    [JsonPropertyName("asset")]
    public required Asset1 Asset { get; init; }
}
