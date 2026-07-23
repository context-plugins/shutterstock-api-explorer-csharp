using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class CreateAccessTokenError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private CreateAccessTokenError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static CreateAccessTokenError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static CreateAccessTokenError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<CreateAccessTokenError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class CreateAccessTokenErrorResponse : IErrorResponse<CreateAccessTokenError>
{
    public static CreateAccessTokenErrorResponse Instance { get; } = new();

    private CreateAccessTokenErrorResponse()
    {
    }

    public Task<CreateAccessTokenError> Map(HttpResponseMessage response, CancellationToken ct) =>
        CreateAccessTokenError.Create(response, ct);
}
