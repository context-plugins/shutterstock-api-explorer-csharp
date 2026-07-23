using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Exceptions;
using ShutterstockApiExplorer.Core.Models;
using ShutterstockApiExplorer.Core.Request;
using ShutterstockApiExplorer.Core.Response;
using ShutterstockApiExplorer.Errors;
using ShutterstockApiExplorer.Models;
using ShutterstockApiExplorer.Models.Enums;

namespace ShutterstockApiExplorer.Api;

public sealed class Catalog
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Catalog(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Add items to catalog collections
    /// </summary>
    /// <param name="collectionId">The ID of the collection to add assets to</param>
    /// <param name="body"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CatalogCollection"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint adds assets to a catalog collection. It also automatically adds the assets to the user's account's catalog.
    /// </remarks>
    public Task<CatalogCollection> AddToCollection(string collectionId,
        CreateCatalogCollectionItems body,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/catalog/collections/{collection_id}/items"),
            [new TemplateParam("collection_id", collectionId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<CatalogCollection>(),
            RawErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// Create catalog collections
    /// </summary>
    /// <param name="body"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CatalogCollection"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint creates a catalog collection and optionally adds assets. To add assets to the collection later, use <c>PATCH /v2/catalog/collections/{collection_id}/items</c>.
    /// </remarks>
    public Task<CatalogCollection> CreateCollection(CreateCatalogCollection body, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/catalog/collections"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<CatalogCollection>(),
            RawErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// Delete catalog collections
    /// </summary>
    /// <param name="collectionId">The ID of the collection to delete</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="DeleteCollectionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint deletes a catalog collection. It does not remove the assets from the user's account's catalog.
    /// </remarks>
    public Task DeleteCollection(string collectionId, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/catalog/collections/{collection_id}"),
            [new TemplateParam("collection_id", collectionId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            DeleteCollectionErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// Remove items from catalog collection
    /// </summary>
    /// <param name="collectionId">The ID of the collection to remove assets from</param>
    /// <param name="body"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CatalogCollection"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint removes assets from a catalog collection. It does not remove the assets from the user's account's catalog.
    /// </remarks>
    public Task<CatalogCollection> DeleteFromCollection(string collectionId,
        RemoveCatalogCollectionItems body,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/catalog/collections/{collection_id}/items"),
            [new TemplateParam("collection_id", collectionId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            JsonRequest.Create(body),
            JsonResponse.Create<CatalogCollection>(),
            RawErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// List catalog collections
    /// </summary>
    /// <param name="sort">Sort by</param>
    /// <param name="page">Page number</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="shared">Set to true to omit collections that you own and return only collections  that are shared with you</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CatalogCollectionDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetCollectionsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint returns a list of catalog collections.
    /// </remarks>
    public Task<CatalogCollectionDataList> GetCollections(Sort1? sort,
        int? page = 1,
        int? perPage = 20,
        bool? shared = false,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/catalog/collections"),
            [],
            [new Param("page", page),
                new Param("per_page", perPage),
                new Param("sort", sort),
                new Param("shared", shared)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CatalogCollectionDataList>(),
            GetCollectionsErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// Search catalogs for assets
    /// </summary>
    /// <param name="sort">Sort by</param>
    /// <param name="query">One or more search terms separated by spaces</param>
    /// <param name="collectionId">Filter by collection id</param>
    /// <param name="assetType">Filter by asset type</param>
    /// <param name="page">Page number</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CatalogCollectionItemDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="SearchCatalogError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint searches for assets in the account's catalog. If you specify more than one search parameter, the API uses an AND condition. Array parameters can be specified multiple times; in this case, the API uses an AND or an OR condition with those values, depending on the parameter. You can also filter search terms out in the <c>query</c> parameter by prefixing the term with NOT.
    /// </remarks>
    public Task<CatalogCollectionItemDataList> SearchCatalog(Sort1? sort,
        string? query,
        IReadOnlyList<string>? collectionId,
        IReadOnlyList<AssetType>? assetType,
        int? page = 1,
        int? perPage = 20,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/catalog/search"),
            [],
            [new Param("sort", sort),
                new Param("page", page),
                new Param("per_page", perPage),
                new Param("query", query),
                new Param("collection_id", collectionId),
                new Param("asset_type", assetType)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CatalogCollectionItemDataList>(),
            SearchCatalogErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// Update collection metadata
    /// </summary>
    /// <param name="collectionId">ID of collection that needs to be modified</param>
    /// <param name="body"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CatalogCollection"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint updates the metadata of a catalog collection.
    /// </remarks>
    public Task<CatalogCollection> UpdateCollection(string collectionId,
        UpdateCatalogCollection body,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/catalog/collections/{collection_id}"),
            [new TemplateParam("collection_id", collectionId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            new HttpMethod("PATCH"),
            JsonRequest.Create(body),
            JsonResponse.Create<CatalogCollection>(),
            RawErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);
}
