using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core;
using ShutterstockApiExplorer.Core.Authentication;
using ShutterstockApiExplorer.Core.Exceptions;
using ShutterstockApiExplorer.Core.Extensions;
using ShutterstockApiExplorer.Core.Models;
using ShutterstockApiExplorer.Core.Request;
using ShutterstockApiExplorer.Core.Response;
using ShutterstockApiExplorer.Errors;
using ShutterstockApiExplorer.Models;
using ShutterstockApiExplorer.Models.Enums;

namespace ShutterstockApiExplorer.Api;

public sealed class EditorialImages
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal EditorialImages(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// (Deprecated) Get editorial content details
    /// </summary>
    /// <param name="id">Editorial ID</param>
    /// <param name="country">Returns only if the content is available for distribution in a certain country</param>
    /// <param name="searchId">The ID of the search that is related to this request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="EditorialContent"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="DeprecatedGetEditorialContentDetailsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Deprecated; use <c>GET /v2/editorial/images/{id}</c> instead to show information about an editorial image, including a URL to a preview image and the sizes that it is available in.
    /// </remarks>
    public Task<EditorialContent> DeprecatedGetEditorialContentDetails(string id,
        string country,
        string? searchId,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/editorial/{id}"),
            [new TemplateParam("id", id)],
            [new Param("country", country), new Param("search_id", searchId)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<EditorialContent>(),
            DeprecatedGetEditorialContentDetailsErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// (Deprecated) List editorial categories
    /// </summary>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="EditorialCategoryResults"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetEditorialCategoriesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Deprecated; use <c>GET /v2/editorial/images/categories</c> instead. This endpoint lists the categories that editorial images can belong to, which are separate from the categories that other types of assets can belong to.
    /// </remarks>
    public Task<EditorialCategoryResults> GetEditorialCategories(CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/editorial/categories"),
            [],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<EditorialCategoryResults>(),
            GetEditorialCategoriesErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// Get editorial content details
    /// </summary>
    /// <param name="id">Editorial ID</param>
    /// <param name="country">Returns only if the content is available for distribution in a certain country</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="EditorialContent"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetEditorialImageError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint shows information about an editorial image, including a URL to a preview image and the sizes that it is available in.
    /// </remarks>
    public Task<EditorialContent> GetEditorialImage(string id, string country, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/editorial/images/{id}"),
            [new TemplateParam("id", id)],
            [new Param("country", country)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<EditorialContent>(),
            GetEditorialImageErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// List editorial image licenses
    /// </summary>
    /// <param name="imageId">Show licenses for the specified editorial image ID</param>
    /// <param name="license">Show editorial images that are available with the specified license name</param>
    /// <param name="sort">Sort order</param>
    /// <param name="username">Filter licenses by username of licensee</param>
    /// <param name="startDate">Show licenses created on or after the specified date</param>
    /// <param name="endDate">Show licenses created before the specified date</param>
    /// <param name="downloadAvailability">Filter licenses by download availability</param>
    /// <param name="page">Page number</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="teamHistory">Set to true to see license history for all members of your team.</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="DownloadHistoryDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetEditorialImageLicenseListError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint lists existing editorial image licenses.
    /// </remarks>
    public Task<DownloadHistoryDataList> GetEditorialImageLicenseList(string? imageId,
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
        _rawClient.Execute(_server.Default("/v2/editorial/images/licenses"),
            [],
            [new Param("image_id", imageId),
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
            GetEditorialImageLicenseListErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// Get editorial livefeed
    /// </summary>
    /// <param name="id">Editorial livefeed ID; must be an URI encoded string</param>
    /// <param name="country">Returns only if the livefeed is available for distribution in a certain country</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="EditorialImageLivefeed"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetEditorialImageLivefeedError"/> when the server returns an error response.</exception>
    public Task<EditorialImageLivefeed> GetEditorialImageLivefeed(string id,
        string country,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/editorial/images/livefeeds/{id}"),
            [new TemplateParam("id", id)],
            [new Param("country", country)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<EditorialImageLivefeed>(),
            GetEditorialImageLivefeedErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// Get editorial livefeed items
    /// </summary>
    /// <param name="id">Editorial livefeed ID; must be an URI encoded string</param>
    /// <param name="country">Returns only if the livefeed items are available for distribution in a certain country</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="EditorialImageContentDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetEditorialImageLivefeedItemsError"/> when the server returns an error response.</exception>
    public Task<EditorialImageContentDataList> GetEditorialImageLivefeedItems(string id,
        string country,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/editorial/images/livefeeds/{id}/items"),
            [new TemplateParam("id", id)],
            [new Param("country", country)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<EditorialImageContentDataList>(),
            GetEditorialImageLivefeedItemsErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// Get editorial livefeed list
    /// </summary>
    /// <param name="country">Returns only livefeeds that are available for distribution in a certain country</param>
    /// <param name="page">Page number</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="EditorialImageLivefeedList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetEditorialImageLivefeedListError"/> when the server returns an error response.</exception>
    public Task<EditorialImageLivefeedList> GetEditorialImageLivefeedList(string country,
        int? page = 1,
        int? perPage = 20,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/editorial/images/livefeeds"),
            [],
            [new Param("country", country), new Param("page", page), new Param("per_page", perPage)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<EditorialImageLivefeedList>(),
            GetEditorialImageLivefeedListErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// (Deprecated) Get editorial livefeed
    /// </summary>
    /// <param name="id">Editorial livefeed ID; must be an URI encoded string</param>
    /// <param name="country">Returns only if the livefeed is available for distribution in a certain country</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="EditorialLivefeed"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetEditorialLivefeedError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Deprecated: use <c>GET /v2/editorial/images/livefeeds/{id}</c> instead to get an editorial livefeed.
    /// </remarks>
    public Task<EditorialLivefeed> GetEditorialLivefeed(string id, string country, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/editorial/livefeeds/{id}"),
            [new TemplateParam("id", id)],
            [new Param("country", country)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<EditorialLivefeed>(),
            GetEditorialLivefeedErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// (Deprecated) Get editorial livefeed items
    /// </summary>
    /// <param name="id">Editorial livefeed ID; must be an URI encoded string</param>
    /// <param name="country">Returns only if the livefeed items are available for distribution in a certain country</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="EditorialContentDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetEditorialLivefeedItemsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Deprecated; use <c>GET /v2/editorial/images/livefeeds/{id}/items</c> instead to get editorial livefeed items.
    /// </remarks>
    public Task<EditorialContentDataList> GetEditorialLivefeedItems(string id,
        string country,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/editorial/livefeeds/{id}/items"),
            [new TemplateParam("id", id)],
            [new Param("country", country)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<EditorialContentDataList>(),
            GetEditorialLivefeedItemsErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// (Deprecated) Get editorial livefeed list
    /// </summary>
    /// <param name="country">Returns only livefeeds that are available for distribution in a certain country</param>
    /// <param name="page">Page number</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="EditorialLivefeedList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetEditorialLivefeedListError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Deprecated; use <c>GET /v2/editorial/images/livefeeds</c> instead to get a list of editorial livefeeds.
    /// </remarks>
    public Task<EditorialLivefeedList> GetEditorialLivefeedList(string country,
        int? page = 1,
        int? perPage = 20,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/editorial/livefeeds"),
            [],
            [new Param("country", country), new Param("page", page), new Param("per_page", perPage)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<EditorialLivefeedList>(),
            GetEditorialLivefeedListErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// (Deprecated) List updated content
    /// </summary>
    /// <param name="type">Specify <c>addition</c> to return only images that were added or <c>edit</c> to return only images that were edited or deleted</param>
    /// <param name="dateUpdatedStart">Show images images added, edited, or deleted after the specified date. Acceptable range is 1970-01-01T00:00:01 to 2038-01-19T00:00:00.</param>
    /// <param name="dateUpdatedEnd">Show images images added, edited, or deleted before the specified date. Acceptable range is 1970-01-01T00:00:01 to 2038-01-19T00:00:00.</param>
    /// <param name="country">Show only editorial content that is available for distribution in a certain country</param>
    /// <param name="dateTakenStart">Show images that were taken on or after the specified date; use this parameter if you want recently created images from the collection instead of updated older assets</param>
    /// <param name="dateTakenEnd">Show images that were taken before the specified date</param>
    /// <param name="cursor">The cursor of the page with which to start fetching results; this cursor is returned from previous requests</param>
    /// <param name="sort">Sort by</param>
    /// <param name="supplierCode">Show only editorial content from certain suppliers</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="EditorialUpdatedResults"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetUpdatedEditorialImageError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Deprecated; use <c>GET /v2/editorial/images/updated</c> instead to get recently updated items.
    /// </remarks>
    public Task<EditorialUpdatedResults> GetUpdatedEditorialImage(Type2 type,
        DateTimeOffset dateUpdatedStart,
        DateTimeOffset dateUpdatedEnd,
        string country,
        DateTimeOffset? dateTakenStart,
        DateTimeOffset? dateTakenEnd,
        string? cursor,
        Sort1? sort,
        IReadOnlyList<string>? supplierCode,
        int? perPage = 500,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/editorial/updated"),
            [],
            [new Param("type", type),
                new Param("date_updated_start", dateUpdatedStart.ToIso8601()),
                new Param("date_updated_end", dateUpdatedEnd.ToIso8601()),
                new Param("country", country),
                new Param("date_taken_start", dateTakenStart?.ToDate()),
                new Param("date_taken_end", dateTakenEnd?.ToDate()),
                new Param("cursor", cursor),
                new Param("sort", sort),
                new Param("supplier_code", supplierCode),
                new Param("per_page", perPage)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<EditorialUpdatedResults>(),
            GetUpdatedEditorialImageErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// List updated content
    /// </summary>
    /// <param name="type">Specify <c>addition</c> to return only images that were added or <c>edit</c> to return only images that were edited or deleted</param>
    /// <param name="dateUpdatedStart">Show images images added, edited, or deleted after the specified date. Acceptable range is 1970-01-01T00:00:01 to 2038-01-19T00:00:00.</param>
    /// <param name="dateUpdatedEnd">Show images images added, edited, or deleted before the specified date. Acceptable range is 1970-01-01T00:00:01 to 2038-01-19T00:00:00.</param>
    /// <param name="country">Show only editorial content that is available for distribution in a certain country</param>
    /// <param name="dateTakenStart">Show images that were taken on or after the specified date; use this parameter if you want recently created images from the collection instead of updated older assets</param>
    /// <param name="dateTakenEnd">Show images that were taken before the specified date</param>
    /// <param name="cursor">The cursor of the page with which to start fetching results; this cursor is returned from previous requests</param>
    /// <param name="sort">Sort by</param>
    /// <param name="supplierCode">Show only editorial content from certain suppliers</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="EditorialUpdatedResults"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetUpdatedEditorialImagesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint lists editorial images that have been updated in the specified time period to update content management systems (CMS) or digital asset management (DAM) systems. In most cases, use the date_updated_start and date_updated_end parameters to specify a range updates based on when the updates happened. You can also use the date_taken_start and date_taken_end parameters to specify a range of updates based on when the image was taken.
    /// </remarks>
    public Task<EditorialUpdatedResults> GetUpdatedEditorialImages(Type2 type,
        DateTimeOffset dateUpdatedStart,
        DateTimeOffset dateUpdatedEnd,
        string country,
        DateTimeOffset? dateTakenStart,
        DateTimeOffset? dateTakenEnd,
        string? cursor,
        Sort1? sort,
        IReadOnlyList<string>? supplierCode,
        int? perPage = 500,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/editorial/images/updated"),
            [],
            [new Param("type", type),
                new Param("date_updated_start", dateUpdatedStart.ToIso8601()),
                new Param("date_updated_end", dateUpdatedEnd.ToIso8601()),
                new Param("country", country),
                new Param("date_taken_start", dateTakenStart?.ToDate()),
                new Param("date_taken_end", dateTakenEnd?.ToDate()),
                new Param("cursor", cursor),
                new Param("sort", sort),
                new Param("supplier_code", supplierCode),
                new Param("per_page", perPage)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<EditorialUpdatedResults>(),
            GetUpdatedEditorialImagesErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// (Deprecated) License editorial content
    /// </summary>
    /// <param name="body"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="LicenseEditorialContentResults"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="LicenseEditorialImageError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Deprecated; use <c>POST /v2/editorial/images/licenses</c> instead to get licenses for one or more editorial images. You must specify the country and one or more editorial images to license. The download links in the response are valid for 8 hours.
    /// </remarks>
    public Task<LicenseEditorialContentResults> LicenseEditorialImage(LicenseEditorialContentRequest body,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/editorial/licenses"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<LicenseEditorialContentResults>(),
            LicenseEditorialImageErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// License editorial content
    /// </summary>
    /// <param name="body"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="LicenseEditorialContentResults"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="LicenseEditorialImagesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint gets licenses for one or more editorial images. You must specify the country and one or more editorial images to license. The download links in the response are valid for 8 hours.
    /// </remarks>
    public Task<LicenseEditorialContentResults> LicenseEditorialImages(LicenseEditorialContentRequest body,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/editorial/images/licenses"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<LicenseEditorialContentResults>(),
            LicenseEditorialImagesErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// List editorial categories
    /// </summary>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="EditorialImageCategoryResults"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListEditorialImageCategoriesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint lists the categories that editorial images can belong to, which are separate from the categories that other types of assets can belong to.
    /// </remarks>
    public Task<EditorialImageCategoryResults> ListEditorialImageCategories(CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/editorial/images/categories"),
            [],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<EditorialImageCategoryResults>(),
            ListEditorialImageCategoriesErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// (Deprecated) Search editorial content
    /// </summary>
    /// <param name="country">Show only editorial content that is available for distribution in a certain country</param>
    /// <param name="query">One or more search terms separated by spaces</param>
    /// <param name="sort">Sort by</param>
    /// <param name="category">Show editorial content within a certain editorial category; specify by category name</param>
    /// <param name="supplierCode">Show only editorial content from certain suppliers</param>
    /// <param name="dateStart">Show only editorial content generated on or after a specific date</param>
    /// <param name="dateEnd">Show only editorial content generated on or before a specific date</param>
    /// <param name="cursor">The cursor of the page with which to start fetching results; this cursor is returned from previous requests</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="EditorialSearchResults"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="SearchEditorialError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Deprecated; use <c>GET /v2/editorial/images/search</c> instead to search for editorial images.
    /// </remarks>
    public Task<EditorialSearchResults> SearchEditorial(string country,
        string? query,
        Sort10? sort,
        string? category,
        IReadOnlyList<string>? supplierCode,
        DateTimeOffset? dateStart,
        DateTimeOffset? dateEnd,
        string? cursor,
        int? perPage = 20,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/editorial/search"),
            [],
            [new Param("country", country),
                new Param("query", query),
                new Param("sort", sort),
                new Param("category", category),
                new Param("supplier_code", supplierCode),
                new Param("date_start", dateStart?.ToDate()),
                new Param("date_end", dateEnd?.ToDate()),
                new Param("per_page", perPage),
                new Param("cursor", cursor)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<EditorialSearchResults>(),
            SearchEditorialErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// Search editorial images
    /// </summary>
    /// <param name="country">Show only editorial content that is available for distribution in a certain country</param>
    /// <param name="query">One or more search terms separated by spaces</param>
    /// <param name="sort">Sort by</param>
    /// <param name="category">Show editorial content with each of the specified editorial categories; specify category names in a comma-separated list</param>
    /// <param name="supplierCode">Show only editorial content from certain suppliers</param>
    /// <param name="dateStart">Show only editorial content generated on or after a specific date</param>
    /// <param name="dateEnd">Show only editorial content generated on or before a specific date</param>
    /// <param name="cursor">The cursor of the page with which to start fetching results; this cursor is returned from previous requests</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="EditorialSearchResults"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="SearchEditorialImagesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint searches for editorial images. If you specify more than one search parameter, the API uses an AND condition. For example, if you set the <c>category</c> parameter to "Alone,Performing" and also specify a <c>query</c> parameter, the results include only images that match the query and are in both the Alone and Performing categories. You can also filter search terms out in the <c>query</c> parameter by prefixing the term with NOT.
    /// </remarks>
    public Task<EditorialSearchResults> SearchEditorialImages(string country,
        string? query,
        Sort10? sort,
        string? category,
        IReadOnlyList<string>? supplierCode,
        DateTimeOffset? dateStart,
        DateTimeOffset? dateEnd,
        string? cursor,
        int? perPage = 20,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/editorial/images/search"),
            [],
            [new Param("country", country),
                new Param("query", query),
                new Param("sort", sort),
                new Param("category", category),
                new Param("supplier_code", supplierCode),
                new Param("date_start", dateStart?.ToDate()),
                new Param("date_end", dateEnd?.ToDate()),
                new Param("per_page", perPage),
                new Param("cursor", cursor)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<EditorialSearchResults>(),
            SearchEditorialImagesErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);
}
