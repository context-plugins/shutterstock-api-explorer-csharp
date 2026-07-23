using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class SearchImagesError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private SearchImagesError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static SearchImagesError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static SearchImagesError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<SearchImagesError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class SearchImagesErrorResponse : IErrorResponse<SearchImagesError>
{
    public static SearchImagesErrorResponse Instance { get; } = new();

    private SearchImagesErrorResponse()
    {
    }

    public Task<SearchImagesError> Map(HttpResponseMessage response, CancellationToken ct) =>
        SearchImagesError.Create(response, ct);
}
