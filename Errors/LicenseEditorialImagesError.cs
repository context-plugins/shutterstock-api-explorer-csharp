using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class LicenseEditorialImagesError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private LicenseEditorialImagesError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static LicenseEditorialImagesError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static LicenseEditorialImagesError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<LicenseEditorialImagesError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 or 406 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class LicenseEditorialImagesErrorResponse : IErrorResponse<LicenseEditorialImagesError>
{
    public static LicenseEditorialImagesErrorResponse Instance { get; } = new();

    private LicenseEditorialImagesErrorResponse()
    {
    }

    public Task<LicenseEditorialImagesError> Map(HttpResponseMessage response, CancellationToken ct) =>
        LicenseEditorialImagesError.Create(response, ct);
}
