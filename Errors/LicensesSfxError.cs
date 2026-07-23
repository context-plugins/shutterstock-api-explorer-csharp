using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class LicensesSfxError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private LicensesSfxError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static LicensesSfxError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static LicensesSfxError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<LicensesSfxError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class LicensesSfxErrorResponse : IErrorResponse<LicensesSfxError>
{
    public static LicensesSfxErrorResponse Instance { get; } = new();

    private LicensesSfxErrorResponse()
    {
    }

    public Task<LicensesSfxError> Map(HttpResponseMessage response, CancellationToken ct) =>
        LicensesSfxError.Create(response, ct);
}
