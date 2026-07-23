using System;
using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Models.Enums;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Catalog collection
/// </summary>
public record CatalogCollection
{
    /// <summary>
    /// Metadata about an item that is part of a collection
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cover_asset")]
    public CatalogCollectionItem? CoverAsset { get; init; }

    [JsonPropertyName("created_time")]
    public required DateTimeOffset CreatedTime { get; init; }

    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// List of role assignments for a catalog collection
    /// </summary>
    [JsonPropertyName("role_assignments")]
    public required CatalogCollectionRoleAssignments RoleAssignments { get; init; }

    [JsonPropertyName("total_item_count")]
    public required double TotalItemCount { get; init; }

    [JsonPropertyName("updated_time")]
    public required DateTimeOffset UpdatedTime { get; init; }

    [JsonPropertyName("visibility")]
    public required Visibility Visibility { get; init; }
}
