using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetVideoCollectionItemsError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetVideoCollectionItemsError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetVideoCollectionItemsError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetVideoCollectionItemsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetVideoCollectionItemsError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 or 404 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetVideoCollectionItemsErrorResponse : IErrorResponse<GetVideoCollectionItemsError>
{
    public static GetVideoCollectionItemsErrorResponse Instance { get; } = new();

    private GetVideoCollectionItemsErrorResponse()
    {
    }

    public Task<GetVideoCollectionItemsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetVideoCollectionItemsError.Create(response, ct);
}
