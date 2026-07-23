using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class UploadEphemeralImageError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private UploadEphemeralImageError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static UploadEphemeralImageError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static UploadEphemeralImageError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<UploadEphemeralImageError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 or 413 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class UploadEphemeralImageErrorResponse : IErrorResponse<UploadEphemeralImageError>
{
    public static UploadEphemeralImageErrorResponse Instance { get; } = new();

    private UploadEphemeralImageErrorResponse()
    {
    }

    public Task<UploadEphemeralImageError> Map(HttpResponseMessage response, CancellationToken ct) =>
        UploadEphemeralImageError.Create(response, ct);
}
