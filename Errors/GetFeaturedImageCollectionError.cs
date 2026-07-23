using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetFeaturedImageCollectionError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetFeaturedImageCollectionError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetFeaturedImageCollectionError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetFeaturedImageCollectionError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetFeaturedImageCollectionError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 or 404 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetFeaturedImageCollectionErrorResponse : IErrorResponse<GetFeaturedImageCollectionError>
{
    public static GetFeaturedImageCollectionErrorResponse Instance { get; } = new();

    private GetFeaturedImageCollectionErrorResponse()
    {
    }

    public Task<GetFeaturedImageCollectionError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetFeaturedImageCollectionError.Create(response, ct);
}
