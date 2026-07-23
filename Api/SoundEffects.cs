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

public sealed class SoundEffects
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal SoundEffects(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Download sound effects
    /// </summary>
    /// <param name="id">License ID</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SfxUrl"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="DownloadSfxError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint redownloads sound effects that you have already received a license for. The download links in the response are valid for 8 hours.
    /// </remarks>
    public Task<SfxUrl> DownloadSfx(string id, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/sfx/licenses/{id}/downloads"),
            [new TemplateParam("id", id)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            EmptyBody.Instance,
            JsonResponse.Create<SfxUrl>(),
            DownloadSfxErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// Get details about sound effects
    /// </summary>
    /// <param name="id">Audio track ID</param>
    /// <param name="language">Language for the keywords and categories in the response</param>
    /// <param name="view">Amount of detail to render in the response</param>
    /// <param name="library">Which library to fetch from</param>
    /// <param name="searchId">The ID of the search that is related to this request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Sfx"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetSfxDetailsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint shows information about a sound effect.
    /// </remarks>
    public Task<Sfx> GetSfxDetails(int id,
        Language? language,
        View1? view,
        Library1? library,
        string? searchId,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/sfx/{id}"),
            [new TemplateParam("id", id)],
            [new Param("language", language),
                new Param("view", view),
                new Param("library", library),
                new Param("search_id", searchId)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Sfx>(),
            GetSfxDetailsErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// List sound effects licenses
    /// </summary>
    /// <param name="sfxId">Show licenses for the specified sound effects ID</param>
    /// <param name="license">Show sound effects that are available with the specified license, such as <c>standard</c> or <c>enhanced</c>; prepending a <c>-</c> sign excludes results from that license</param>
    /// <param name="sort">Sort order</param>
    /// <param name="username">Filter licenses by username of licensee</param>
    /// <param name="startDate">Show licenses created on or after the specified date</param>
    /// <param name="endDate">Show licenses created before the specified date</param>
    /// <param name="licenseId">Filter by the license ID</param>
    /// <param name="downloadAvailability">Filter licenses by download availability</param>
    /// <param name="page">Page number</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="teamHistory">Set to true to see license history for all members of your team.</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="DownloadHistoryDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetSfxLicenseListError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint lists existing licenses.
    /// </remarks>
    public Task<DownloadHistoryDataList> GetSfxLicenseList(string? sfxId,
        string? license,
        Sort1? sort,
        string? username,
        DateTimeOffset? startDate,
        DateTimeOffset? endDate,
        string? licenseId,
        DownloadAvailability? downloadAvailability,
        int? page = 1,
        int? perPage = 20,
        bool? teamHistory = false,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/sfx/licenses"),
            [],
            [new Param("sfx_id", sfxId),
                new Param("license", license),
                new Param("page", page),
                new Param("per_page", perPage),
                new Param("sort", sort),
                new Param("username", username),
                new Param("start_date", startDate?.ToIso8601()),
                new Param("end_date", endDate?.ToIso8601()),
                new Param("license_id", licenseId),
                new Param("download_availability", downloadAvailability),
                new Param("team_history", teamHistory)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<DownloadHistoryDataList>(),
            GetSfxLicenseListErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// List details about sound effects
    /// </summary>
    /// <param name="id">One or more sound effect IDs</param>
    /// <param name="view">Amount of detail to render in the response</param>
    /// <param name="language">Language for the keywords and categories in the response</param>
    /// <param name="library">Which library to fetch from</param>
    /// <param name="searchId">The ID of the search that is related to this request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SfxdataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetSfxListDetailsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint shows information about sound effects.
    /// </remarks>
    public Task<SfxdataList> GetSfxListDetails(IReadOnlyList<string> id,
        View1? view,
        Language? language,
        Library1? library,
        string? searchId,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/sfx"),
            [],
            [new Param("id", id),
                new Param("view", view),
                new Param("language", language),
                new Param("library", library),
                new Param("search_id", searchId)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<SfxdataList>(),
            GetSfxListDetailsErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// License sound effects
    /// </summary>
    /// <param name="body"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="LicenseSfxresultDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="LicensesSfxError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint licenses sounds effect assets.
    /// </remarks>
    public Task<LicenseSfxresultDataList> LicensesSfx(LicenseSfxrequest body, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/sfx/licenses"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<LicenseSfxresultDataList>(),
            LicensesSfxErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// Search for sound effects
    /// </summary>
    /// <param name="addedDate">Show sound effects added on the specified date</param>
    /// <param name="addedDateStart">Show sound effects added on or after the specified date</param>
    /// <param name="addedDateEnd">Show sound effects added before the specified date</param>
    /// <param name="duration">Show sound effects with the specified duration in seconds</param>
    /// <param name="durationFrom">Show sound effects with the specified duration or longer in seconds</param>
    /// <param name="durationTo">Show sound effects with the specified duration or shorter in seconds</param>
    /// <param name="query">One or more search terms separated by spaces</param>
    /// <param name="sort">Sort by</param>
    /// <param name="view">Amount of detail to render in the response</param>
    /// <param name="language">Set query and result language (uses Accept-Language header if not set)</param>
    /// <param name="page">Page number</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="safe">Enable or disable safe search</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SfxsearchResults"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="SearchSfxError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint searches for sound effects. If you specify more than one search parameter, the API uses an AND condition.
    /// </remarks>
    public Task<SfxsearchResults> SearchSfx(DateTimeOffset? addedDate,
        DateTimeOffset? addedDateStart,
        DateTimeOffset? addedDateEnd,
        int? duration,
        int? durationFrom,
        int? durationTo,
        string? query,
        Sort21? sort,
        View1? view,
        Language? language,
        int? page = 1,
        int? perPage = 20,
        bool? safe = true,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/sfx/search"),
            [],
            [new Param("added_date", addedDate?.ToDate()),
                new Param("added_date_start", addedDateStart?.ToDate()),
                new Param("added_date_end", addedDateEnd?.ToDate()),
                new Param("duration", duration),
                new Param("duration_from", durationFrom),
                new Param("duration_to", durationTo),
                new Param("page", page),
                new Param("per_page", perPage),
                new Param("query", query),
                new Param("safe", safe),
                new Param("sort", sort),
                new Param("view", view),
                new Param("language", language)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<SfxsearchResults>(),
            SearchSfxErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);
}
