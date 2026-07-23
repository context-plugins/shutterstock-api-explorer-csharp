using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class EchoError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private EchoError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static EchoError AsNoContent(RawError value) => new(Optional<RawError>.Some(value), default);

    private static EchoError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<EchoError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class EchoErrorResponse : IErrorResponse<EchoError>
{
    public static EchoErrorResponse Instance { get; } = new();

    private EchoErrorResponse()
    {
    }

    public Task<EchoError> Map(HttpResponseMessage response, CancellationToken ct) =>
        EchoError.Create(response, ct);
}
