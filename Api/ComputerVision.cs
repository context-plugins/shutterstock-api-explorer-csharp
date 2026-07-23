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
using ShutterstockApiExplorer.Models.AnyOf;
using ShutterstockApiExplorer.Models.Enums;

namespace ShutterstockApiExplorer.Api;

public sealed class ComputerVision
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal ComputerVision(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// List suggested keywords
    /// </summary>
    /// <param name="assetId">The asset ID or upload ID to suggest keywords for</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="KeywordDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetKeywordsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint returns a list of suggested keywords for a media item that you specify or upload.
    /// </remarks>
    public Task<KeywordDataList> GetKeywords(AssetId assetId, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/cv/keywords"),
            [],
            [new Param("asset_id", assetId)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<KeywordDataList>(),
            GetKeywordsErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// List similar images
    /// </summary>
    /// <param name="assetId">The asset ID or upload ID to find similar images for</param>
    /// <param name="license">Show only images with the specified license</param>
    /// <param name="language">Language for the keywords and categories in the response</param>
    /// <param name="view">Amount of detail to render in the response</param>
    /// <param name="safe">Enable or disable safe search</param>
    /// <param name="page">Page number</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ImageSearchResults"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetSimilarImagesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint returns images that are visually similar to an image that you specify or upload.
    /// </remarks>
    public Task<ImageSearchResults> GetSimilarImages(string assetId,
        IReadOnlyList<License5>? license,
        Language? language,
        View1? view,
        bool? safe = true,
        int? page = 1,
        int? perPage = 20,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/cv/similar/images"),
            [],
            [new Param("asset_id", assetId),
                new Param("license", license),
                new Param("safe", safe),
                new Param("language", language),
                new Param("page", page),
                new Param("per_page", perPage),
                new Param("view", view)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ImageSearchResults>(),
            GetSimilarImagesErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// List similar videos
    /// </summary>
    /// <param name="assetId">The asset ID or upload ID to find similar videos for</param>
    /// <param name="license">Show only videos with the specified license</param>
    /// <param name="language">Language for the keywords and categories in the response</param>
    /// <param name="view">Amount of detail to render in the response</param>
    /// <param name="safe">Enable or disable safe search</param>
    /// <param name="page">Page number</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="VideoSearchResults"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetSimilarVideosError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint returns videos that are visually similar to an image that you specify or upload.
    /// </remarks>
    public Task<VideoSearchResults> GetSimilarVideos(string assetId,
        IReadOnlyList<License5>? license,
        Language? language,
        View1? view,
        bool? safe = true,
        int? page = 1,
        int? perPage = 20,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/cv/similar/videos"),
            [],
            [new Param("asset_id", assetId),
                new Param("license", license),
                new Param("safe", safe),
                new Param("language", language),
                new Param("page", page),
                new Param("per_page", perPage),
                new Param("view", view)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<VideoSearchResults>(),
            GetSimilarVideosErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// Upload ephemeral images
    /// </summary>
    /// <param name="body"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ImageCreateResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="UploadEphemeralImageError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Deprecated; use <c>POST /v2/cv/images</c> instead. This endpoint uploads an image for reverse image search. The image must be in JPEG or PNG format. To get the search results, pass the ID that this endpoint returns to the <c>GET /v2/images/{id}/similar</c> endpoint.
    /// </remarks>
    public Task<ImageCreateResponse> UploadEphemeralImage(ImageCreateRequest body, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/images"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<ImageCreateResponse>(),
            UploadEphemeralImageErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// Upload images
    /// </summary>
    /// <param name="body"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ComputerVisionImageCreateResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="UploadImageError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint uploads an image for reverse image or video search. Images must be in JPEG or PNG format. To get the search results, pass the upload ID that this endpoint returns to the GET /v2/cv/similar/images or GET /v2/cv/similar/videos endpoints. Contact us for access to this endpoint.
    /// </remarks>
    public Task<ComputerVisionImageCreateResponse> UploadImage(ImageCreateRequest body,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/cv/images"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<ComputerVisionImageCreateResponse>(),
            UploadImageErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);
}
