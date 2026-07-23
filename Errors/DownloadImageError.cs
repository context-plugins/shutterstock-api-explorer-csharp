using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class DownloadImageError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private DownloadImageError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static DownloadImageError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static DownloadImageError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<DownloadImageError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class DownloadImageErrorResponse : IErrorResponse<DownloadImageError>
{
    public static DownloadImageErrorResponse Instance { get; } = new();

    private DownloadImageErrorResponse()
    {
    }

    public Task<DownloadImageError> Map(HttpResponseMessage response, CancellationToken ct) =>
        DownloadImageError.Create(response, ct);
}
