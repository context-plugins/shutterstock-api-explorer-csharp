using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetFeaturedVideoCollectionListError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetFeaturedVideoCollectionListError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetFeaturedVideoCollectionListError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetFeaturedVideoCollectionListError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetFeaturedVideoCollectionListError> Create(HttpResponseMessage response,
        CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetFeaturedVideoCollectionListErrorResponse : IErrorResponse<GetFeaturedVideoCollectionListError>
{
    public static GetFeaturedVideoCollectionListErrorResponse Instance { get; } = new();

    private GetFeaturedVideoCollectionListErrorResponse()
    {
    }

    public Task<GetFeaturedVideoCollectionListError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetFeaturedVideoCollectionListError.Create(response, ct);
}
