using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetUserError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetUserError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetUserError AsNoContent(RawError value) => new(Optional<RawError>.Some(value), default);

    private static GetUserError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetUserError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetUserErrorResponse : IErrorResponse<GetUserError>
{
    public static GetUserErrorResponse Instance { get; } = new();

    private GetUserErrorResponse()
    {
    }

    public Task<GetUserError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetUserError.Create(response, ct);
}
