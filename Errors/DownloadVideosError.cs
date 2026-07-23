using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class DownloadVideosError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private DownloadVideosError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static DownloadVideosError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static DownloadVideosError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<DownloadVideosError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class DownloadVideosErrorResponse : IErrorResponse<DownloadVideosError>
{
    public static DownloadVideosErrorResponse Instance { get; } = new();

    private DownloadVideosErrorResponse()
    {
    }

    public Task<DownloadVideosError> Map(HttpResponseMessage response, CancellationToken ct) =>
        DownloadVideosError.Create(response, ct);
}
