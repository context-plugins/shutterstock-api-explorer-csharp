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

public sealed class AudioModel
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal AudioModel(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Add audio tracks to collections
    /// </summary>
    /// <param name="id">Collection ID</param>
    /// <param name="body"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="AddTrackCollectionItemsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint adds one or more tracks to a collection by track IDs.
    /// </remarks>
    public Task AddTrackCollectionItems(string id, CollectionItemRequest body, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/audio/collections/{id}/items"),
            [new TemplateParam("id", id)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            VoidResponse.Instance,
            AddTrackCollectionItemsErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// Create audio collections
    /// </summary>
    /// <param name="body"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CollectionCreateResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="CreateTrackCollectionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint creates one or more collections (soundboxes). To add tracks, use <c>POST /v2/audio/collections/{id}/items</c>.
    /// </remarks>
    public Task<CollectionCreateResponse> CreateTrackCollection(CollectionCreateRequest body,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/audio/collections"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<CollectionCreateResponse>(),
            CreateTrackCollectionErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// Delete audio collections
    /// </summary>
    /// <param name="id">Collection ID</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="DeleteTrackCollectionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint deletes a collection.
    /// </remarks>
    public Task DeleteTrackCollection(string id, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/audio/collections/{id}"),
            [new TemplateParam("id", id)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            DeleteTrackCollectionErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// Remove audio tracks from collections
    /// </summary>
    /// <param name="id">Collection ID</param>
    /// <param name="itemId">One or more item IDs to remove from the collection</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="DeleteTrackCollectionItemsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint removes one or more tracks from a collection.
    /// </remarks>
    public Task DeleteTrackCollectionItems(string id, IReadOnlyList<string>? itemId, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/audio/collections/{id}/items"),
            [new TemplateParam("id", id)],
            [new Param("item_id", itemId)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            DeleteTrackCollectionItemsErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// Download audio tracks
    /// </summary>
    /// <param name="id">License ID</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AudioUrl"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="DownloadTracksError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint redownloads tracks that you have already received a license for. The download links in the response are valid for 8 hours.
    /// </remarks>
    public Task<AudioUrl> DownloadTracks(string id, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/audio/licenses/{id}/downloads"),
            [new TemplateParam("id", id)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            EmptyBody.Instance,
            JsonResponse.Create<AudioUrl>(),
            DownloadTracksErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// Get details about audio tracks
    /// </summary>
    /// <param name="id">Audio track ID</param>
    /// <param name="view">Amount of detail to render in the response</param>
    /// <param name="searchId">The ID of the search that is related to this request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Audio"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetTrackError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint shows information about a track, including its genres, instruments, and other attributes.
    /// </remarks>
    public Task<Audio> GetTrack(int id, View1? view, string? searchId, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/audio/{id}"),
            [new TemplateParam("id", id)],
            [new Param("view", view), new Param("search_id", searchId)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Audio>(),
            GetTrackErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// Get the details of audio collections
    /// </summary>
    /// <param name="id">Collection ID</param>
    /// <param name="embed">Which sharing information to include in the response, such as a URL to the collection</param>
    /// <param name="shareCode">Code to retrieve a shared collection</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Collection"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetTrackCollectionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint gets more detailed information about a collection, including the number of items in it and when it was last updated. To get the tracks in collections, use <c>GET /v2/audio/collections/{id}/items</c>.
    /// </remarks>
    public Task<Collection> GetTrackCollection(string id,
        IReadOnlyList<Embed>? embed,
        string? shareCode,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/audio/collections/{id}"),
            [new TemplateParam("id", id)],
            [new Param("embed", embed), new Param("share_code", shareCode)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Collection>(),
            GetTrackCollectionErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// Get the contents of audio collections
    /// </summary>
    /// <param name="id">Collection ID</param>
    /// <param name="shareCode">Code to retrieve the contents of a shared collection</param>
    /// <param name="sort">Sort order</param>
    /// <param name="page">Page number</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CollectionItemDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetTrackCollectionItemsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint lists the IDs of tracks in a collection and the date that each was added.
    /// </remarks>
    public Task<CollectionItemDataList> GetTrackCollectionItems(string id,
        string? shareCode,
        Sort1? sort,
        int? page = 1,
        int? perPage = 100,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/audio/collections/{id}/items"),
            [new TemplateParam("id", id)],
            [new Param("page", page),
                new Param("per_page", perPage),
                new Param("share_code", shareCode),
                new Param("sort", sort)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CollectionItemDataList>(),
            GetTrackCollectionItemsErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// List audio collections
    /// </summary>
    /// <param name="embed">Which sharing information to include in the response, such as a URL to the collection</param>
    /// <param name="page">Page number</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CollectionDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetTrackCollectionListError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint lists your collections of audio tracks and their basic attributes.
    /// </remarks>
    public Task<CollectionDataList> GetTrackCollectionList(IReadOnlyList<Embed>? embed,
        int? page = 1,
        int? perPage = 100,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/audio/collections"),
            [],
            [new Param("page", page), new Param("per_page", perPage), new Param("embed", embed)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CollectionDataList>(),
            GetTrackCollectionListErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// List audio licenses
    /// </summary>
    /// <param name="audioId">Show licenses for the specified track ID</param>
    /// <param name="license">Restrict results by license. Prepending a <c>-</c> sign will exclude results by license</param>
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
    /// <exception cref="SdkException{TResult}"> of <see cref="GetTrackLicenseListError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint lists existing licenses. You can filter the results according to the track ID to see if you have an existing license for a specific track.
    /// </remarks>
    public Task<DownloadHistoryDataList> GetTrackLicenseList(string? audioId,
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
        _rawClient.Execute(_server.Default("/v2/audio/licenses"),
            [],
            [new Param("audio_id", audioId),
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
            GetTrackLicenseListErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// List audio tracks
    /// </summary>
    /// <param name="id">One or more audio IDs</param>
    /// <param name="view">Amount of detail to render in the response</param>
    /// <param name="searchId">The ID of the search that is related to this request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AudioDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetTrackListError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint lists information about one or more audio tracks, including the description and publication date.
    /// </remarks>
    public Task<AudioDataList> GetTrackList(IReadOnlyList<string> id,
        View1? view,
        string? searchId,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/audio"),
            [],
            [new Param("id", id), new Param("view", view), new Param("search_id", searchId)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<AudioDataList>(),
            GetTrackListErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// License audio tracks
    /// </summary>
    /// <param name="license">License type</param>
    /// <param name="searchId">The ID of the search that led to licensing this track</param>
    /// <param name="body"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="LicenseAudioResultDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="LicenseTrackError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint gets licenses for one or more tracks. The download links in the response are valid for 8 hours.
    /// </remarks>
    public Task<LicenseAudioResultDataList> LicenseTrack(License3? license,
        string? searchId,
        LicenseAudioRequest body,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/audio/licenses"),
            [],
            [new Param("license", license), new Param("search_id", searchId)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<LicenseAudioResultDataList>(),
            LicenseTrackErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// List audio genres
    /// </summary>
    /// <param name="language">Which language the genres will be returned</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GenreList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint returns a list of all audio genres.
    /// </remarks>
    public Task<GenreList> ListGenres(string? language, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/audio/genres"),
            [],
            [new Param("language", language)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GenreList>(),
            RawErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// List audio instruments
    /// </summary>
    /// <param name="language">Which language the instruments will be returned in</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="InstrumentList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint returns a list of all audio instruments.
    /// </remarks>
    public Task<InstrumentList> ListInstruments(string? language, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/audio/instruments"),
            [],
            [new Param("language", language)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<InstrumentList>(),
            RawErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// List audio moods
    /// </summary>
    /// <param name="language">Which language the moods will be returned in</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="MoodList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint returns a list of all audio moods.
    /// </remarks>
    public Task<MoodList> ListMoods(string? language, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/audio/moods"),
            [],
            [new Param("language", language)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<MoodList>(),
            RawErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// Rename audio collections
    /// </summary>
    /// <param name="id">Collection ID</param>
    /// <param name="body"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="RenameTrackCollectionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint sets a new name for a collection.
    /// </remarks>
    public Task RenameTrackCollection(string id, CollectionUpdateRequest body, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/audio/collections/{id}"),
            [new TemplateParam("id", id)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            VoidResponse.Instance,
            RenameTrackCollectionErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// Search for tracks
    /// </summary>
    /// <param name="artists">Show tracks with one of the specified artist names or IDs</param>
    /// <param name="bpm">(Deprecated; use bpm_from and bpm_to instead) Show tracks with the specified beats per minute</param>
    /// <param name="bpmFrom">Show tracks with the specified beats per minute or faster</param>
    /// <param name="bpmTo">Show tracks with the specified beats per minute or slower</param>
    /// <param name="duration">Show tracks with the specified duration in seconds</param>
    /// <param name="durationFrom">Show tracks with the specified duration or longer in seconds</param>
    /// <param name="durationTo">Show tracks with the specified duration or shorter in seconds</param>
    /// <param name="genre">Show tracks with each of the specified genres; to get the list of genres, use <c>GET /v2/audio/genres</c></param>
    /// <param name="isInstrumental">Show instrumental music only</param>
    /// <param name="instruments">Show tracks with each of the specified instruments; to get the list of instruments, use <c>GET /v2/audio/instruments</c></param>
    /// <param name="moods">Show tracks with each of the specified moods; to get the list of moods, use <c>GET /v2/audio/moods</c></param>
    /// <param name="query">One or more search terms separated by spaces</param>
    /// <param name="sort">Sort by</param>
    /// <param name="sortOrder">Sort order</param>
    /// <param name="vocalDescription">Show tracks with the specified vocal description (male, female)</param>
    /// <param name="view">Amount of detail to render in the response</param>
    /// <param name="fields">Fields to display in the response; see the documentation for the fields parameter in the overview section</param>
    /// <param name="library">Which library to search</param>
    /// <param name="language">Which language to search in</param>
    /// <param name="page">Page number</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AudioSearchResults"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="SearchTracksError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint searches for tracks. If you specify more than one search parameter, the API uses an AND condition. Array parameters can be specified multiple times; in this case, the API uses an AND or an OR condition with those values, depending on the parameter.
    /// </remarks>
    public Task<AudioSearchResults> SearchTracks(IReadOnlyList<string>? artists,
        int? bpm,
        int? bpmFrom,
        int? bpmTo,
        int? duration,
        int? durationFrom,
        int? durationTo,
        IReadOnlyList<string>? genre,
        bool? isInstrumental,
        IReadOnlyList<string>? instruments,
        IReadOnlyList<string>? moods,
        string? query,
        Sort3? sort,
        SortOrder? sortOrder,
        string? vocalDescription,
        View1? view,
        string? fields,
        Library? library,
        string? language,
        int? page = 1,
        int? perPage = 20,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/audio/search"),
            [],
            [new Param("artists", artists),
                new Param("bpm", bpm),
                new Param("bpm_from", bpmFrom),
                new Param("bpm_to", bpmTo),
                new Param("duration", duration),
                new Param("duration_from", durationFrom),
                new Param("duration_to", durationTo),
                new Param("genre", genre),
                new Param("is_instrumental", isInstrumental),
                new Param("instruments", instruments),
                new Param("moods", moods),
                new Param("page", page),
                new Param("per_page", perPage),
                new Param("query", query),
                new Param("sort", sort),
                new Param("sort_order", sortOrder),
                new Param("vocal_description", vocalDescription),
                new Param("view", view),
                new Param("fields", fields),
                new Param("library", library),
                new Param("language", language)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<AudioSearchResults>(),
            SearchTracksErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);
}
