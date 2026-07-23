using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class DownloadTracksError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private DownloadTracksError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static DownloadTracksError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static DownloadTracksError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<DownloadTracksError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class DownloadTracksErrorResponse : IErrorResponse<DownloadTracksError>
{
    public static DownloadTracksErrorResponse Instance { get; } = new();

    private DownloadTracksErrorResponse()
    {
    }

    public Task<DownloadTracksError> Map(HttpResponseMessage response, CancellationToken ct) =>
        DownloadTracksError.Create(response, ct);
}
