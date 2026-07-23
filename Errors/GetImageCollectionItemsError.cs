using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetImageCollectionItemsError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetImageCollectionItemsError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetImageCollectionItemsError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetImageCollectionItemsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetImageCollectionItemsError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 or 404 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetImageCollectionItemsErrorResponse : IErrorResponse<GetImageCollectionItemsError>
{
    public static GetImageCollectionItemsErrorResponse Instance { get; } = new();

    private GetImageCollectionItemsErrorResponse()
    {
    }

    public Task<GetImageCollectionItemsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetImageCollectionItemsError.Create(response, ct);
}
