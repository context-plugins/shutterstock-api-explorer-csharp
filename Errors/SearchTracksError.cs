using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class SearchTracksError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private SearchTracksError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static SearchTracksError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static SearchTracksError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<SearchTracksError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class SearchTracksErrorResponse : IErrorResponse<SearchTracksError>
{
    public static SearchTracksErrorResponse Instance { get; } = new();

    private SearchTracksErrorResponse()
    {
    }

    public Task<SearchTracksError> Map(HttpResponseMessage response, CancellationToken ct) =>
        SearchTracksError.Create(response, ct);
}
