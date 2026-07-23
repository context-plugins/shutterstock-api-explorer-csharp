using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class DownloadSfxError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private DownloadSfxError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static DownloadSfxError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static DownloadSfxError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<DownloadSfxError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class DownloadSfxErrorResponse : IErrorResponse<DownloadSfxError>
{
    public static DownloadSfxErrorResponse Instance { get; } = new();

    private DownloadSfxErrorResponse()
    {
    }

    public Task<DownloadSfxError> Map(HttpResponseMessage response, CancellationToken ct) =>
        DownloadSfxError.Create(response, ct);
}
