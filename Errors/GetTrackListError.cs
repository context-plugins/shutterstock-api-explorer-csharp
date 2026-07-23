using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetTrackListError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetTrackListError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetTrackListError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetTrackListError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetTrackListError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetTrackListErrorResponse : IErrorResponse<GetTrackListError>
{
    public static GetTrackListErrorResponse Instance { get; } = new();

    private GetTrackListErrorResponse()
    {
    }

    public Task<GetTrackListError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetTrackListError.Create(response, ct);
}
