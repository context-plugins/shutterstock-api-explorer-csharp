using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class LicenseTrackError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private LicenseTrackError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static LicenseTrackError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static LicenseTrackError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<LicenseTrackError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class LicenseTrackErrorResponse : IErrorResponse<LicenseTrackError>
{
    public static LicenseTrackErrorResponse Instance { get; } = new();

    private LicenseTrackErrorResponse()
    {
    }

    public Task<LicenseTrackError> Map(HttpResponseMessage response, CancellationToken ct) =>
        LicenseTrackError.Create(response, ct);
}
