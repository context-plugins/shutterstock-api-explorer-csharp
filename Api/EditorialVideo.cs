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

public sealed class EditorialVideo
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal EditorialVideo(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Get editorial video content details
    /// </summary>
    /// <param name="id">Editorial ID</param>
    /// <param name="country">Returns only if the content is available for distribution in a certain country</param>
    /// <param name="searchId">The ID of the search that is related to this request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="EditorialVideoContent"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetEditorialVideoError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint shows information about an editorial image, including a URL to a preview image and the sizes that it is available in.
    /// </remarks>
    public Task<EditorialVideoContent> GetEditorialVideo(string id,
        string country,
        string? searchId,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/editorial/videos/{id}"),
            [new TemplateParam("id", id)],
            [new Param("country", country), new Param("search_id", searchId)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<EditorialVideoContent>(),
            GetEditorialVideoErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// List editorial video licenses
    /// </summary>
    /// <param name="videoId">Show licenses for the specified editorial video ID</param>
    /// <param name="license">Show editorial videos that are available with the specified license name</param>
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
    /// <exception cref="SdkException{TResult}"> of <see cref="GetEditorialVideoLicenseListError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint lists existing editorial video licenses.
    /// </remarks>
    public Task<DownloadHistoryDataList> GetEditorialVideoLicenseList(string? videoId,
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
        _rawClient.Execute(_server.Default("/v2/editorial/videos/licenses"),
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
            GetEditorialVideoLicenseListErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// License editorial video content
    /// </summary>
    /// <param name="body"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="LicenseEditorialContentResults"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="LicenseEditorialVideoError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint gets licenses for one or more editorial videos. You must specify the country and one or more editorial videos to license. The download links in the response are valid for 8 hours.
    /// </remarks>
    public Task<LicenseEditorialContentResults> LicenseEditorialVideo(LicenseEditorialVideoContentRequest body,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/editorial/videos/licenses"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<LicenseEditorialContentResults>(),
            LicenseEditorialVideoErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// List editorial video categories
    /// </summary>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="EditorialVideoCategoryResults"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListEditorialVideoCategoriesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint lists the categories that editorial videos can belong to, which are separate from the categories that other types of assets can belong to.
    /// </remarks>
    public Task<EditorialVideoCategoryResults> ListEditorialVideoCategories(CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/editorial/videos/categories"),
            [],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<EditorialVideoCategoryResults>(),
            ListEditorialVideoCategoriesErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// Search editorial video content
    /// </summary>
    /// <param name="country">Show only editorial video content that is available for distribution in a certain country</param>
    /// <param name="query">One or more search terms separated by spaces</param>
    /// <param name="sort">Sort by</param>
    /// <param name="category">Show editorial content with each of the specified editorial categories; specify category names in a comma-separated list</param>
    /// <param name="supplierCode">Show only editorial video content from certain suppliers</param>
    /// <param name="dateStart">Show only editorial video content generated on or after a specific date</param>
    /// <param name="dateEnd">Show only editorial video content generated on or before a specific date</param>
    /// <param name="resolution">Show only editorial video content with specific resolution</param>
    /// <param name="fps">Show only editorial video content generated with specific frames per second</param>
    /// <param name="cursor">The cursor of the page with which to start fetching results; this cursor is returned from previous requests</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="EditorialVideoSearchResults"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="SearchEditorialVideosError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint searches for editorial videos. If you specify more than one search parameter, the API uses an AND condition. For example, if you set the <c>category</c> parameter to "Alone,Performing" and also specify a <c>query</c> parameter, the results include only videos that match the query and are in both the Alone and Performing categories.  You can also filter search terms out in the <c>query</c> parameter by prefixing the term with NOT.
    /// </remarks>
    public Task<EditorialVideoSearchResults> SearchEditorialVideos(string country,
        string? query,
        Sort10? sort,
        string? category,
        IReadOnlyList<string>? supplierCode,
        DateTimeOffset? dateStart,
        DateTimeOffset? dateEnd,
        Resolution? resolution,
        double? fps,
        string? cursor,
        int? perPage = 20,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/editorial/videos/search"),
            [],
            [new Param("country", country),
                new Param("query", query),
                new Param("sort", sort),
                new Param("category", category),
                new Param("supplier_code", supplierCode),
                new Param("date_start", dateStart?.ToDate()),
                new Param("date_end", dateEnd?.ToDate()),
                new Param("resolution", resolution),
                new Param("fps", fps),
                new Param("per_page", perPage),
                new Param("cursor", cursor)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<EditorialVideoSearchResults>(),
            SearchEditorialVideosErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);
}
