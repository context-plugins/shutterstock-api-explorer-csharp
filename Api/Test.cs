using System.Collections.Generic;
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

namespace ShutterstockApiExplorer.Api;

public sealed class Test
{
    private readonly RawClient _rawClient;
    private readonly Server _server;

    internal Test(RawClient rawClient, Server server)
    {
        _rawClient = rawClient;
        _server = server;
    }

    /// <summary>
    /// Echo text
    /// </summary>
    /// <param name="text">Text to echo</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="TestEcho"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="EchoError"/> when the server returns an error response.</exception>
    public Task<TestEcho> Echo(string? text = "ok", CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/test"),
            [],
            [new Param("text", text)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<TestEcho>(),
            EchoErrorResponse.Instance,
            [],
            ct);

    /// <summary>
    /// Validate input
    /// </summary>
    /// <param name="id">Integer ID</param>
    /// <param name="tag">List of tags</param>
    /// <param name="userAgent">User agent</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="TestValidate"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ValidateError"/> when the server returns an error response.</exception>
    public Task<TestValidate> Validate(int id,
        IReadOnlyList<string>? tag,
        string? userAgent,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/test/validate"),
            [],
            [new Param("id", id), new Param("tag", tag)],
            [new HeaderParam("user-agent", userAgent)],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<TestValidate>(),
            ValidateErrorResponse.Instance,
            [],
            ct);
}
