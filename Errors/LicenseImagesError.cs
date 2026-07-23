using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class LicenseImagesError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private LicenseImagesError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static LicenseImagesError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static LicenseImagesError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<LicenseImagesError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class LicenseImagesErrorResponse : IErrorResponse<LicenseImagesError>
{
    public static LicenseImagesErrorResponse Instance { get; } = new();

    private LicenseImagesErrorResponse()
    {
    }

    public Task<LicenseImagesError> Map(HttpResponseMessage response, CancellationToken ct) =>
        LicenseImagesError.Create(response, ct);
}
