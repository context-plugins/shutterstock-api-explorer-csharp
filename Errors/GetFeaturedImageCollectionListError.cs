using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetFeaturedImageCollectionListError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetFeaturedImageCollectionListError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetFeaturedImageCollectionListError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetFeaturedImageCollectionListError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetFeaturedImageCollectionListError> Create(HttpResponseMessage response,
        CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetFeaturedImageCollectionListErrorResponse : IErrorResponse<GetFeaturedImageCollectionListError>
{
    public static GetFeaturedImageCollectionListErrorResponse Instance { get; } = new();

    private GetFeaturedImageCollectionListErrorResponse()
    {
    }

    public Task<GetFeaturedImageCollectionListError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetFeaturedImageCollectionListError.Create(response, ct);
}
