using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core;
using ShutterstockApiExplorer.Core.Authentication;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Exceptions;
using ShutterstockApiExplorer.Core.Extensions;
using ShutterstockApiExplorer.Core.Models;
using ShutterstockApiExplorer.Core.Request;
using ShutterstockApiExplorer.Core.Response;
using ShutterstockApiExplorer.Errors;
using ShutterstockApiExplorer.Models;
using ShutterstockApiExplorer.Models.Enums;

namespace ShutterstockApiExplorer.Api;

public sealed class Videos
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Videos(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Add videos to collections
    /// </summary>
    /// <param name="id">The ID of the collection to which items should be added</param>
    /// <param name="body"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="AddVideoCollectionItemsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint adds one or more videos to a collection by video IDs.
    /// </remarks>
    public Task AddVideoCollectionItems(string id, CollectionItemRequest body, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/videos/collections/{id}/items"),
            [new TemplateParam("id", id)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            VoidResponse.Instance,
            AddVideoCollectionItemsErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// Create video collections
    /// </summary>
    /// <param name="body"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CollectionCreateResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="CreateVideoCollectionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint creates one or more collections (clipboxes). To add videos to collections, use <c>POST /v2/videos/collections/{id}/items</c>.
    /// </remarks>
    public Task<CollectionCreateResponse> CreateVideoCollection(CollectionCreateRequest body,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/videos/collections"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<CollectionCreateResponse>(),
            CreateVideoCollectionErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// Delete video collections
    /// </summary>
    /// <param name="id">The ID of the collection to delete</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="DeleteVideoCollectionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint deletes a collection.
    /// </remarks>
    public Task DeleteVideoCollection(string id, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/videos/collections/{id}"),
            [new TemplateParam("id", id)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            DeleteVideoCollectionErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// Remove videos from collections
    /// </summary>
    /// <param name="id">The ID of the Collection from which items will be deleted</param>
    /// <param name="itemId">One or more video IDs to remove from the collection</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="DeleteVideoCollectionItemsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint removes one or more videos from a collection.
    /// </remarks>
    public Task DeleteVideoCollectionItems(string id, IReadOnlyList<string>? itemId, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/videos/collections/{id}/items"),
            [new TemplateParam("id", id)],
            [new Param("item_id", itemId)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            DeleteVideoCollectionItemsErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// Download videos
    /// </summary>
    /// <param name="id">The license ID of the item to (re)download. The download links in the response are valid for 8 hours.</param>
    /// <param name="body"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Url"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="DownloadVideosError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint redownloads videos that you have already received a license for.
    /// </remarks>
    public Task<Url> DownloadVideos(string id, RedownloadVideo body, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/videos/licenses/{id}/downloads"),
            [new TemplateParam("id", id)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<Url>(),
            DownloadVideosErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// List similar videos
    /// </summary>
    /// <param name="id">The ID of a video for which similar videos should be returned</param>
    /// <param name="language">Language for the keywords and categories in the response</param>
    /// <param name="view">Amount of detail to render in the response</param>
    /// <param name="page">Page number</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="VideoSearchResults"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="FindSimilarVideosError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint searches for videos that are similar to a video that you specify.
    /// </remarks>
    public Task<VideoSearchResults> FindSimilarVideos(string id,
        Language? language,
        View1? view,
        int? page = 1,
        int? perPage = 20,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/videos/{id}/similar"),
            [new TemplateParam("id", id)],
            [new Param("language", language),
                new Param("page", page),
                new Param("per_page", perPage),
                new Param("view", view)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<VideoSearchResults>(),
            FindSimilarVideosErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// Get the details of featured video collections
    /// </summary>
    /// <param name="id">Collection ID</param>
    /// <param name="embed">What information to include in the response, such as a URL to the collection</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="FeaturedCollection"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetFeaturedVideoCollectionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint gets more detailed information about a featured video collection, including its cover video and timestamps for its creation and most recent update. To get the videos, use <c>GET /v2/videos/collections/featured/{id}/items</c>.
    /// </remarks>
    public Task<FeaturedCollection> GetFeaturedVideoCollection(string id,
        Embed3? embed,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/videos/collections/featured/{id}"),
            [new TemplateParam("id", id)],
            [new Param("embed", embed)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<FeaturedCollection>(),
            GetFeaturedVideoCollectionErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// Get the contents of featured video collections
    /// </summary>
    /// <param name="id">Collection ID</param>
    /// <param name="page">Page number</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="VideoCollectionItemDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetFeaturedVideoCollectionItemsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint lists the IDs of videos in a featured collection and the date that each was added.
    /// </remarks>
    public Task<VideoCollectionItemDataList> GetFeaturedVideoCollectionItems(string id,
        int? page = 1,
        int? perPage = 100,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/videos/collections/featured/{id}/items"),
            [new TemplateParam("id", id)],
            [new Param("page", page), new Param("per_page", perPage)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<VideoCollectionItemDataList>(),
            GetFeaturedVideoCollectionItemsErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// List featured video collections
    /// </summary>
    /// <param name="embed">What information to include in the response, such as a URL to the collection</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="FeaturedCollectionDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetFeaturedVideoCollectionListError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint lists featured video collections and a name and cover video for each collection.
    /// </remarks>
    public Task<FeaturedCollectionDataList> GetFeaturedVideoCollectionList(Embed3? embed,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/videos/collections/featured"),
            [],
            [new Param("embed", embed)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<FeaturedCollectionDataList>(),
            GetFeaturedVideoCollectionListErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// List updated videos
    /// </summary>
    /// <param name="startDate">Show videos updated on or after the specified date</param>
    /// <param name="endDate">Show videos updated before the specified date</param>
    /// <param name="sort">Sort by oldest or newest videos first</param>
    /// <param name="interval">Show videos updated in the specified time period, where the time period is an interval (like SQL INTERVAL) such as 1 DAY, 6 HOUR, or 30 MINUTE; the default is 1 HOUR, which shows videos that were updated in the hour preceding the request</param>
    /// <param name="page">Page number</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="UpdatedMediaDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint lists videos that have been updated in the specified time period to update content management systems (CMS) or digital asset management (DAM) systems. In most cases, use the <c>interval</c> parameter to show videos that were updated recently, but you can also use the <c>start_date</c> and <c>end_date</c> parameters to specify a range of no more than three days. Do not use the <c>interval</c> parameter with either <c>start_date</c> or <c>end_date</c>.
    /// </remarks>
    public Task<UpdatedMediaDataList> GetUpdatedVideos(DateTimeOffset? startDate,
        DateTimeOffset? endDate,
        Sort1? sort,
        string? interval = "1 HOUR",
        int? page = 1,
        int? perPage = 100,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/videos/updated"),
            [],
            [new Param("start_date", startDate?.ToDate()),
                new Param("end_date", endDate?.ToDate()),
                new Param("interval", interval),
                new Param("page", page),
                new Param("per_page", perPage),
                new Param("sort", sort)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<UpdatedMediaDataList>(),
            RawErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// Get details about videos
    /// </summary>
    /// <param name="id">Video ID</param>
    /// <param name="language">Language for the keywords and categories in the response</param>
    /// <param name="view">Amount of detail to render in the response</param>
    /// <param name="searchId">The ID of the search that is related to this request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Video"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetVideoError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint shows information about a video, including URLs to previews and the sizes that it is available in.
    /// </remarks>
    public Task<Video> GetVideo(string id,
        Language? language,
        View1? view,
        string? searchId,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/videos/{id}"),
            [new TemplateParam("id", id)],
            [new Param("language", language), new Param("view", view), new Param("search_id", searchId)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Video>(),
            GetVideoErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// Get the details of video collections
    /// </summary>
    /// <param name="id">The ID of the collection to return</param>
    /// <param name="embed">Which sharing information to include in the response, such as a URL to the collection</param>
    /// <param name="shareCode">Code to retrieve a shared collection</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Collection"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetVideoCollectionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint gets more detailed information about a collection, including the timestamp for its creation and the number of videos in it. To get the videos in collections, use GET /v2/videos/collections/{id}/items.
    /// </remarks>
    public Task<Collection> GetVideoCollection(string id,
        IReadOnlyList<Embed>? embed,
        string? shareCode,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/videos/collections/{id}"),
            [new TemplateParam("id", id)],
            [new Param("embed", embed), new Param("share_code", shareCode)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Collection>(),
            GetVideoCollectionErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// Get the contents of video collections
    /// </summary>
    /// <param name="id">Collection ID</param>
    /// <param name="shareCode">Code to retrieve the contents of a shared collection</param>
    /// <param name="sort">Sort order</param>
    /// <param name="page">Page number</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CollectionItemDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetVideoCollectionItemsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint lists the IDs of videos in a collection and the date that each was added.
    /// </remarks>
    public Task<CollectionItemDataList> GetVideoCollectionItems(string id,
        string? shareCode,
        Sort1? sort,
        int? page = 1,
        int? perPage = 100,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/videos/collections/{id}/items"),
            [new TemplateParam("id", id)],
            [new Param("page", page),
                new Param("per_page", perPage),
                new Param("share_code", shareCode),
                new Param("sort", sort)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CollectionItemDataList>(),
            GetVideoCollectionItemsErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// List video collections
    /// </summary>
    /// <param name="embed">Which sharing information to include in the response, such as a URL to the collection</param>
    /// <param name="page">Page number</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CollectionDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetVideoCollectionListError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint lists your collections of videos and their basic attributes.
    /// </remarks>
    public Task<CollectionDataList> GetVideoCollectionList(IReadOnlyList<Embed>? embed,
        int? page = 1,
        int? perPage = 100,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/videos/collections"),
            [],
            [new Param("page", page), new Param("per_page", perPage), new Param("embed", embed)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CollectionDataList>(),
            GetVideoCollectionListErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// List video licenses
    /// </summary>
    /// <param name="videoId">Show licenses for the specified video ID</param>
    /// <param name="license">Show videos that are available with the specified license, such as <c>standard</c> or <c>enhanced</c>; prepending a <c>-</c> sign excludes results from that license</param>
    /// <param name="sort">Sort by oldest or newest videos first</param>
    /// <param name="username">Filter licenses by username of licensee</param>
    /// <param name="startDate">Show licenses created on or after the specified date</param>
    /// <param name="endDate">Show licenses created before the specified date</param>
    /// <param name="downloadAvailability">Filter licenses by download availability</param>
    /// <param name="page">Page number</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="teamHistory">Set to true to see license history for all members of your team.</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="DownloadHistoryDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetVideoLicenseListError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint lists existing licenses.
    /// </remarks>
    public Task<DownloadHistoryDataList> GetVideoLicenseList(string? videoId,
        string? license,
        Sort1? sort,
        string? username,
        DateTimeOffset? startDate,
        DateTimeOffset? endDate,
        DownloadAvailability? downloadAvailability,
        int? page = 1,
        int? perPage = 20,
        bool? teamHistory = false,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/videos/licenses"),
            [],
            [new Param("video_id", videoId),
                new Param("license", license),
                new Param("page", page),
                new Param("per_page", perPage),
                new Param("sort", sort),
                new Param("username", username),
                new Param("start_date", startDate?.ToIso8601()),
                new Param("end_date", endDate?.ToIso8601()),
                new Param("download_availability", downloadAvailability),
                new Param("team_history", teamHistory)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<DownloadHistoryDataList>(),
            GetVideoLicenseListErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// List videos
    /// </summary>
    /// <param name="id">One or more video IDs</param>
    /// <param name="view">Amount of detail to render in the response</param>
    /// <param name="searchId">The ID of the search that is related to this request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="VideoDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetVideoListError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint lists information about one or more videos, including the aspect ratio and URLs to previews.
    /// </remarks>
    public Task<VideoDataList> GetVideoList(IReadOnlyList<string> id,
        View1? view,
        string? searchId,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/videos"),
            [],
            [new Param("id", id), new Param("view", view), new Param("search_id", searchId)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<VideoDataList>(),
            GetVideoListErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// Get suggestions for a search term
    /// </summary>
    /// <param name="query">Search term for which you want keyword suggestions</param>
    /// <param name="limit">Limit the number of the suggestions</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Suggestions"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetVideoSuggestionsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint provides autocomplete suggestions for partial search terms.
    /// </remarks>
    public Task<Suggestions> GetVideoSuggestions(string query, int? limit = 10, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/videos/search/suggestions"),
            [],
            [new Param("query", query), new Param("limit", limit)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Suggestions>(),
            GetVideoSuggestionsErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// License videos
    /// </summary>
    /// <param name="subscriptionId">The subscription ID to use for licensing</param>
    /// <param name="size">The size of the video to license</param>
    /// <param name="searchId">The Search ID that led to this licensing event</param>
    /// <param name="body"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="LicenseVideoResultDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="LicenseVideosError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint gets licenses for one or more videos. You must specify the video IDs in the body parameter and the size and subscription ID either in the query parameter or with each video ID in the body parameter. Values in the body parameter override values in the query parameters. The download links in the response are valid for 8 hours.
    /// </remarks>
    public Task<LicenseVideoResultDataList> LicenseVideos(string? subscriptionId,
        Size9? size,
        string? searchId,
        LicenseVideoRequest body,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/videos/licenses"),
            [],
            [new Param("subscription_id", subscriptionId),
                new Param("size", size),
                new Param("search_id", searchId)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<LicenseVideoResultDataList>(),
            LicenseVideosErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// List video categories
    /// </summary>
    /// <param name="language">Language for the keywords and categories in the response</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CategoryDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListVideoCategoriesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint lists the categories (Shutterstock-assigned genres) that videos can belong to.
    /// </remarks>
    public Task<CategoryDataList> ListVideoCategories(Language? language, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/videos/categories"),
            [],
            [new Param("language", language)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CategoryDataList>(),
            ListVideoCategoriesErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// Rename video collections
    /// </summary>
    /// <param name="id">The ID of the collection to rename</param>
    /// <param name="body"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="RenameVideoCollectionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint sets a new name for a collection.
    /// </remarks>
    public Task RenameVideoCollection(string id, CollectionUpdateRequest body, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/videos/collections/{id}"),
            [new TemplateParam("id", id)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            VoidResponse.Instance,
            RenameVideoCollectionErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// Search for videos
    /// </summary>
    /// <param name="addedDate">Show videos added on the specified date</param>
    /// <param name="addedDateStart">Show videos added on or after the specified date</param>
    /// <param name="addedDateEnd">Show videos added before the specified date</param>
    /// <param name="aspectRatio">Show videos with the specified aspect ratio</param>
    /// <param name="category">Show videos with the specified Shutterstock-defined category; specify a category name or ID</param>
    /// <param name="contributor">Show videos with the specified artist names or IDs</param>
    /// <param name="contributorCountry">Show videos from contributors in one or more specified countries</param>
    /// <param name="duration">(Deprecated; use duration_from and duration_to instead) Show videos with the specified duration in seconds</param>
    /// <param name="durationFrom">Show videos with the specified duration or longer in seconds</param>
    /// <param name="durationTo">Show videos with the specified duration or shorter in seconds</param>
    /// <param name="fps">(Deprecated; use fps_from and fps_to instead) Show videos with the specified frames per second</param>
    /// <param name="fpsFrom">Show videos with the specified frames per second or more</param>
    /// <param name="fpsTo">Show videos with the specified frames per second or fewer</param>
    /// <param name="language">Set query and result language (uses Accept-Language header if not set)</param>
    /// <param name="license">Show only videos with the specified license or licenses</param>
    /// <param name="model">Show videos with each of the specified models</param>
    /// <param name="peopleAge">Show videos that feature people of the specified age range</param>
    /// <param name="peopleEthnicity">Show videos with people of the specified ethnicities</param>
    /// <param name="peopleGender">Show videos with people with the specified gender</param>
    /// <param name="peopleNumber">Show videos with the specified number of people</param>
    /// <param name="peopleModelReleased">Show only videos of people with a signed model release</param>
    /// <param name="query">One or more search terms separated by spaces; you can use NOT to filter out videos that match a term</param>
    /// <param name="resolution">Show videos with the specified resolution</param>
    /// <param name="sort">Sort by one of these categories</param>
    /// <param name="view">Amount of detail to render in the response</param>
    /// <param name="keywordSafeSearch">Hide results with potentially unsafe keywords</param>
    /// <param name="page">Page number</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="safe">Enable or disable safe search</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="VideoSearchResults"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="SearchVideosError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint searches for videos. If you specify more than one search parameter, the API uses an AND condition. Array parameters can be specified multiple times; in this case, the API uses an AND or an OR condition with those values, depending on the parameter. You can also filter search terms out in the <c>query</c> parameter by prefixing the term with NOT.
    /// </remarks>
    public Task<VideoSearchResults> SearchVideos(DateTimeOffset? addedDate,
        DateTimeOffset? addedDateStart,
        DateTimeOffset? addedDateEnd,
        AspectRatio? aspectRatio,
        string? category,
        IReadOnlyList<string>? contributor,
        IReadOnlyList<string>? contributorCountry,
        int? duration,
        int? durationFrom,
        int? durationTo,
        double? fps,
        double? fpsFrom,
        double? fpsTo,
        Language? language,
        IReadOnlyList<License5>? license,
        IReadOnlyList<string>? model,
        PeopleAge1? peopleAge,
        IReadOnlyList<PeopleEthnicity3>? peopleEthnicity,
        PeopleGender1? peopleGender,
        int? peopleNumber,
        bool? peopleModelReleased,
        string? query,
        Resolution? resolution,
        Sort4? sort,
        View1? view,
        bool? keywordSafeSearch = true,
        int? page = 1,
        int? perPage = 20,
        bool? safe = true,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/videos/search"),
            [],
            [new Param("added_date", addedDate?.ToDate()),
                new Param("added_date_start", addedDateStart?.ToDate()),
                new Param("added_date_end", addedDateEnd?.ToDate()),
                new Param("aspect_ratio", aspectRatio),
                new Param("category", category),
                new Param("contributor", contributor),
                new Param("contributor_country", contributorCountry),
                new Param("duration", duration),
                new Param("duration_from", durationFrom),
                new Param("duration_to", durationTo),
                new Param("fps", fps),
                new Param("fps_from", fpsFrom),
                new Param("fps_to", fpsTo),
                new Param("keyword_safe_search", keywordSafeSearch),
                new Param("language", language),
                new Param("license", license),
                new Param("model", model),
                new Param("page", page),
                new Param("per_page", perPage),
                new Param("people_age", peopleAge),
                new Param("people_ethnicity", peopleEthnicity),
                new Param("people_gender", peopleGender),
                new Param("people_number", peopleNumber),
                new Param("people_model_released", peopleModelReleased),
                new Param("query", query),
                new Param("resolution", resolution),
                new Param("safe", safe),
                new Param("sort", sort),
                new Param("view", view)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<VideoSearchResults>(),
            SearchVideosErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);
}
