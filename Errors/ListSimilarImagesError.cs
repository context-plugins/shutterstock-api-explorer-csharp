using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class ListSimilarImagesError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private ListSimilarImagesError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static ListSimilarImagesError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static ListSimilarImagesError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<ListSimilarImagesError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class ListSimilarImagesErrorResponse : IErrorResponse<ListSimilarImagesError>
{
    public static ListSimilarImagesErrorResponse Instance { get; } = new();

    private ListSimilarImagesErrorResponse()
    {
    }

    public Task<ListSimilarImagesError> Map(HttpResponseMessage response, CancellationToken ct) =>
        ListSimilarImagesError.Create(response, ct);
}
