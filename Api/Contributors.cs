using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core;
using ShutterstockApiExplorer.Core.Authentication;
using ShutterstockApiExplorer.Core.Exceptions;
using ShutterstockApiExplorer.Core.Models;
using ShutterstockApiExplorer.Core.Request;
using ShutterstockApiExplorer.Core.Response;
using ShutterstockApiExplorer.Errors;
using ShutterstockApiExplorer.Models;
using ShutterstockApiExplorer.Models.Enums;

namespace ShutterstockApiExplorer.Api;

public sealed class Contributors
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Contributors(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Get details about a single contributor
    /// </summary>
    /// <param name="contributorId">Contributor ID</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ContributorProfile"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetContributorError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint shows information about a single contributor, including contributor type, equipment they use, and other attributes.
    /// </remarks>
    public Task<ContributorProfile> GetContributor(string contributorId, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/contributors/{contributor_id}"),
            [new TemplateParam("contributor_id", contributorId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ContributorProfile>(),
            GetContributorErrorResponse.Instance,
            [new AuthSchemeAny(_auth.CustomerAccessCode, _auth.Basic)],
            ct);

    /// <summary>
    /// Get the items in contributors' collections
    /// </summary>
    /// <param name="contributorId">Contributor ID</param>
    /// <param name="id">Collection ID that belongs to the contributor</param>
    /// <param name="sort">Sort order</param>
    /// <param name="page">Page number</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CollectionItemDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetContributorCollectionItemsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint lists the IDs of items in a contributor's collection and the date that each was added.
    /// </remarks>
    public Task<CollectionItemDataList> GetContributorCollectionItems(string contributorId,
        string id,
        Sort1? sort,
        int? page = 1,
        int? perPage = 20,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/contributors/{contributor_id}/collections/{id}/items"),
            [new TemplateParam("contributor_id", contributorId), new TemplateParam("id", id)],
            [new Param("page", page), new Param("per_page", perPage), new Param("sort", sort)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CollectionItemDataList>(),
            GetContributorCollectionItemsErrorResponse.Instance,
            [new AuthSchemeAny(_auth.CustomerAccessCode, _auth.Basic)],
            ct);

    /// <summary>
    /// Get details about contributors' collections
    /// </summary>
    /// <param name="contributorId">Contributor ID</param>
    /// <param name="id">Collection ID that belongs to the contributor</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Collection"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetContributorCollectionsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint gets more detailed information about a contributor's collection, including its cover image, timestamps for its creation, and most recent update. To get the items in collections, use GET /v2/contributors/{contributor_id}/collections/{id}/items.
    /// </remarks>
    public Task<Collection> GetContributorCollections(string contributorId,
        string id,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/contributors/{contributor_id}/collections/{id}"),
            [new TemplateParam("contributor_id", contributorId), new TemplateParam("id", id)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Collection>(),
            GetContributorCollectionsErrorResponse.Instance,
            [new AuthSchemeAny(_auth.CustomerAccessCode, _auth.Basic)],
            ct);

    /// <summary>
    /// List contributors' collections
    /// </summary>
    /// <param name="contributorId">Contributor ID</param>
    /// <param name="sort">Sort order</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CollectionDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetContributorCollectionsListError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint lists collections based on contributor ID.
    /// </remarks>
    public Task<CollectionDataList> GetContributorCollectionsList(string contributorId,
        Sort7? sort,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/contributors/{contributor_id}/collections"),
            [new TemplateParam("contributor_id", contributorId)],
            [new Param("sort", sort)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CollectionDataList>(),
            GetContributorCollectionsListErrorResponse.Instance,
            [new AuthSchemeAny(_auth.CustomerAccessCode, _auth.Basic)],
            ct);

    /// <summary>
    /// Get details about multiple contributors
    /// </summary>
    /// <param name="id">One or more contributor IDs</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ContributorProfileDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetContributorListError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint lists information about one or more contributors, including contributor type, equipment they use and other attributes.
    /// </remarks>
    public Task<ContributorProfileDataList> GetContributorList(IReadOnlyList<string> id,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/contributors"),
            [],
            [new Param("id", id)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ContributorProfileDataList>(),
            GetContributorListErrorResponse.Instance,
            [new AuthSchemeAny(_auth.CustomerAccessCode, _auth.Basic)],
            ct);
}
