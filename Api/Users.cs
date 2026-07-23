using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core;
using ShutterstockApiExplorer.Core.Exceptions;
using ShutterstockApiExplorer.Core.Request;
using ShutterstockApiExplorer.Core.Response;
using ShutterstockApiExplorer.Errors;
using ShutterstockApiExplorer.Models;

namespace ShutterstockApiExplorer.Api;

public sealed class Users
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Users(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Get access token details
    /// </summary>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AccessTokenDetails"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetAccessTokenError"/> when the server returns an error response.</exception>
    public Task<AccessTokenDetails> GetAccessToken(CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/user/access_token"),
            [],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<AccessTokenDetails>(),
            GetAccessTokenErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// Get user details
    /// </summary>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="UserDetails"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetUserError"/> when the server returns an error response.</exception>
    public Task<UserDetails> GetUser(CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/user"),
            [],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<UserDetails>(),
            GetUserErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// List user subscriptions
    /// </summary>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SubscriptionDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetUserSubscriptionListError"/> when the server returns an error response.</exception>
    public Task<SubscriptionDataList> GetUserSubscriptionList(CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/user/subscriptions"),
            [],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<SubscriptionDataList>(),
            GetUserSubscriptionListErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);
}
