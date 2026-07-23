using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// List of role assignments for a catalog collection
/// </summary>
public record CatalogCollectionRoleAssignments
{
    [JsonPropertyName("collection_id")]
    public required string CollectionId { get; init; }

    [JsonPropertyName("roles")]
    public required Roles Roles { get; init; }
}
