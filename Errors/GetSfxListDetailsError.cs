using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetSfxListDetailsError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetSfxListDetailsError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetSfxListDetailsError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetSfxListDetailsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetSfxListDetailsError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetSfxListDetailsErrorResponse : IErrorResponse<GetSfxListDetailsError>
{
    public static GetSfxListDetailsErrorResponse Instance { get; } = new();

    private GetSfxListDetailsErrorResponse()
    {
    }

    public Task<GetSfxListDetailsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetSfxListDetailsError.Create(response, ct);
}
