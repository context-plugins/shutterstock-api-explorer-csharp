using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetEditorialImageLivefeedItemsError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetEditorialImageLivefeedItemsError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetEditorialImageLivefeedItemsError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetEditorialImageLivefeedItemsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetEditorialImageLivefeedItemsError> Create(HttpResponseMessage response,
        CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 or 404 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetEditorialImageLivefeedItemsErrorResponse : IErrorResponse<GetEditorialImageLivefeedItemsError>
{
    public static GetEditorialImageLivefeedItemsErrorResponse Instance { get; } = new();

    private GetEditorialImageLivefeedItemsErrorResponse()
    {
    }

    public Task<GetEditorialImageLivefeedItemsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetEditorialImageLivefeedItemsError.Create(response, ct);
}
