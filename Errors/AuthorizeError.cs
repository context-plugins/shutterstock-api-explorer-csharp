using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class AuthorizeError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private AuthorizeError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static AuthorizeError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static AuthorizeError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<AuthorizeError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class AuthorizeErrorResponse : IErrorResponse<AuthorizeError>
{
    public static AuthorizeErrorResponse Instance { get; } = new();

    private AuthorizeErrorResponse()
    {
    }

    public Task<AuthorizeError> Map(HttpResponseMessage response, CancellationToken ct) =>
        AuthorizeError.Create(response, ct);
}
