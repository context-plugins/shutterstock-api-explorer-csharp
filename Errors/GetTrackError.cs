using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetTrackError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetTrackError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetTrackError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetTrackError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetTrackError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetTrackErrorResponse : IErrorResponse<GetTrackError>
{
    public static GetTrackErrorResponse Instance { get; } = new();

    private GetTrackErrorResponse()
    {
    }

    public Task<GetTrackError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetTrackError.Create(response, ct);
}
