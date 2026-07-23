using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class UploadImageError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private UploadImageError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static UploadImageError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static UploadImageError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<UploadImageError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 or 413 or 415 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class UploadImageErrorResponse : IErrorResponse<UploadImageError>
{
    public static UploadImageErrorResponse Instance { get; } = new();

    private UploadImageErrorResponse()
    {
    }

    public Task<UploadImageError> Map(HttpResponseMessage response, CancellationToken ct) =>
        UploadImageError.Create(response, ct);
}
