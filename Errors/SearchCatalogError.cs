using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class SearchCatalogError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private SearchCatalogError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static SearchCatalogError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static SearchCatalogError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<SearchCatalogError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class SearchCatalogErrorResponse : IErrorResponse<SearchCatalogError>
{
    public static SearchCatalogErrorResponse Instance { get; } = new();

    private SearchCatalogErrorResponse()
    {
    }

    public Task<SearchCatalogError> Map(HttpResponseMessage response, CancellationToken ct) =>
        SearchCatalogError.Create(response, ct);
}
