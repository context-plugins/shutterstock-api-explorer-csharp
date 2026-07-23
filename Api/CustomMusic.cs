using System;
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

namespace ShutterstockApiExplorer.Api;

public sealed class CustomMusic
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal CustomMusic(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create rendered audio
    /// </summary>
    /// <param name="body"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AudioRendersListResults"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="CreateAudioRendersError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint creates rendered audio from timeline data. It returns a render ID that you can use to download the finished audio when it is ready. The render ID is valid for up to 48 hours.
    /// </remarks>
    public Task<AudioRendersListResults> CreateAudioRenders(CreateAudioRendersRequest body,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/ai/audio/renders"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<AudioRendersListResults>(),
            CreateAudioRendersErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// Get details about audio renders
    /// </summary>
    /// <param name="id">One or more render IDs</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AudioRendersListResults"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="FetchRendersError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint shows the status of one or more audio renders, including download links for completed audio.
    /// </remarks>
    public Task<AudioRendersListResults> FetchRenders(IReadOnlyList<string> id, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/ai/audio/renders"),
            [],
            [new Param("id", id)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<AudioRendersListResults>(),
            FetchRendersErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// List computer audio descriptors
    /// </summary>
    /// <param name="renderSpeedOver">Show descriptors with an average render speed that is greater than or equal to the specified value</param>
    /// <param name="bandId">Show descriptors that contain the specified band (case-sentsitive)</param>
    /// <param name="bandName">Show descriptors with the specified band name (case-sensitive)</param>
    /// <param name="id">Show descriptors with the specified IDs (case-sensitive)</param>
    /// <param name="instrumentName">Show descriptors with the specified instrument name (case-sensitive)</param>
    /// <param name="instrumentId">Show descriptors with the specified instrument ID (case-sensitive)</param>
    /// <param name="tempo">Show descriptors whose tempo range includes the specified tempo in beats per minute</param>
    /// <param name="tempoTo">Show descriptors with a tempo that is less than or equal to the specified number</param>
    /// <param name="tempoFrom">Show descriptors that have a tempo range that includes the specified tempo in beats per minute</param>
    /// <param name="name">Show descriptors with the specified name (case-sensitive)</param>
    /// <param name="tag">Show descriptors with the specified tag, such as Cinematic or Roomy (case-sensitive)</param>
    /// <param name="page">Page number</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="DescriptorsListResult"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListCustomDescriptorsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint lists the descriptors that you can use in the audio regions in an audio render.
    /// </remarks>
    public Task<DescriptorsListResult> ListCustomDescriptors(double? renderSpeedOver,
        string? bandId,
        string? bandName,
        IReadOnlyList<string>? id,
        string? instrumentName,
        string? instrumentId,
        double? tempo,
        double? tempoTo,
        double? tempoFrom,
        string? name,
        string? tag,
        int? page = 1,
        int? perPage = 20,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/ai/audio/descriptors"),
            [],
            [new Param("render_speed_over", renderSpeedOver),
                new Param("band_id", bandId),
                new Param("band_name", bandName),
                new Param("page", page),
                new Param("per_page", perPage),
                new Param("id", id),
                new Param("instrument_name", instrumentName),
                new Param("instrument_id", instrumentId),
                new Param("tempo", tempo),
                new Param("tempo_to", tempoTo),
                new Param("tempo_from", tempoFrom),
                new Param("name", name),
                new Param("tag", tag)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<DescriptorsListResult>(),
            ListCustomDescriptorsErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// List computer audio instruments
    /// </summary>
    /// <param name="id">Show instruments with the specified ID</param>
    /// <param name="name">Show instruments with the specified name (case-sensitive)</param>
    /// <param name="tag">Show instruments with the specified tag, such as Percussion or Strings (case-sensitive)</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="page">Page number</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="InstrumentsListResult"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListCustomInstrumentsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint lists the instruments that you can include in computer audio. If you specify more than one search parameter, the API uses an AND condition.
    /// </remarks>
    public Task<InstrumentsListResult> ListCustomInstruments(IReadOnlyList<string>? id,
        string? name,
        string? tag,
        int? perPage = 20,
        int? page = 1,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/ai/audio/instruments"),
            [],
            [new Param("id", id),
                new Param("per_page", perPage),
                new Param("page", page),
                new Param("name", name),
                new Param("tag", tag)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<InstrumentsListResult>(),
            ListCustomInstrumentsErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);
}
