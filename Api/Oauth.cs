using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core;
using ShutterstockApiExplorer.Core.Exceptions;
using ShutterstockApiExplorer.Core.Models;
using ShutterstockApiExplorer.Core.Request;
using ShutterstockApiExplorer.Core.Response;
using ShutterstockApiExplorer.Errors;
using ShutterstockApiExplorer.Models;
using ShutterstockApiExplorer.Models.Enums;

namespace ShutterstockApiExplorer.Api;

public sealed class Oauth
{
    private readonly RawClient _rawClient;
    private readonly Server _server;

    internal Oauth(RawClient rawClient, Server server)
    {
        _rawClient = rawClient;
        _server = server;
    }

    /// <summary>
    /// Authorize applications
    /// </summary>
    /// <param name="clientId">Client ID (Consumer Key) of your application</param>
    /// <param name="redirectUri">The callback URI to send the request to after authorization; must use a host name that is registered with your application</param>
    /// <param name="responseType">Type of temporary authorization code that will be used to generate an access code; the only valid value is 'code'</param>
    /// <param name="state">Unique value used by the calling app to verify the request</param>
    /// <param name="realm">User type to be authorized (usually 'customer')</param>
    /// <param name="scope">Space-separated list of scopes to be authorized</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="AuthorizeError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint returns a redirect URI (in the 'Location' header) that the customer uses to authorize your application and, together with POST /v2/oauth/access_token, generate an access token that represents that authorization.
    /// </remarks>
    public Task Authorize(string clientId,
        string redirectUri,
        ResponseType responseType,
        string state,
        Realm2? realm,
        string? scope = "user.view",
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/oauth/authorize"),
            [],
            [new Param("client_id", clientId),
                new Param("redirect_uri", redirectUri),
                new Param("response_type", responseType),
                new Param("state", state),
                new Param("realm", realm),
                new Param("scope", scope)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            VoidResponse.Instance,
            AuthorizeErrorResponse.Instance,
            [],
            ct);

    /// <summary>
    /// Get access tokens
    /// </summary>
    /// <param name="clientId"></param>
    /// <param name="grantType"></param>
    /// <param name="clientSecret"></param>
    /// <param name="code"></param>
    /// <param name="expires"></param>
    /// <param name="realm"></param>
    /// <param name="refreshToken"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="OauthAccessTokenResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="CreateAccessTokenError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint returns an access token for the specified user and with the specified scopes. The token does not expire until the user changes their password. The body parameters must be encoded as form data.
    /// </remarks>
    public Task<OauthAccessTokenResponse> CreateAccessToken(string clientId,
        GrantType grantType,
        string? clientSecret,
        string? code,
        Expires? expires,
        Realm1? realm,
        string? refreshToken,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/oauth/access_token"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            FormUrlEncodedRequest.Create([new Param("client_id", clientId),
                    new Param("grant_type", grantType),
                    new Param("client_secret", clientSecret),
                    new Param("code", code),
                    new Param("expires", expires),
                    new Param("realm", realm),
                    new Param("refresh_token", refreshToken)]),
            JsonResponse.Create<OauthAccessTokenResponse>(),
            CreateAccessTokenErrorResponse.Instance,
            [],
            ct);
}
