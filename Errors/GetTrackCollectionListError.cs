using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetTrackCollectionListError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetTrackCollectionListError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetTrackCollectionListError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetTrackCollectionListError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetTrackCollectionListError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetTrackCollectionListErrorResponse : IErrorResponse<GetTrackCollectionListError>
{
    public static GetTrackCollectionListErrorResponse Instance { get; } = new();

    private GetTrackCollectionListErrorResponse()
    {
    }

    public Task<GetTrackCollectionListError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetTrackCollectionListError.Create(response, ct);
}
