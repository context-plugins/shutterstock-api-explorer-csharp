using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class LicenseEditorialVideoError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private LicenseEditorialVideoError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static LicenseEditorialVideoError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static LicenseEditorialVideoError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<LicenseEditorialVideoError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class LicenseEditorialVideoErrorResponse : IErrorResponse<LicenseEditorialVideoError>
{
    public static LicenseEditorialVideoErrorResponse Instance { get; } = new();

    private LicenseEditorialVideoErrorResponse()
    {
    }

    public Task<LicenseEditorialVideoError> Map(HttpResponseMessage response, CancellationToken ct) =>
        LicenseEditorialVideoError.Create(response, ct);
}
