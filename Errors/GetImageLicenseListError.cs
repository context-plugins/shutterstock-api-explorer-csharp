using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetImageLicenseListError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetImageLicenseListError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetImageLicenseListError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetImageLicenseListError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetImageLicenseListError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetImageLicenseListErrorResponse : IErrorResponse<GetImageLicenseListError>
{
    public static GetImageLicenseListErrorResponse Instance { get; } = new();

    private GetImageLicenseListErrorResponse()
    {
    }

    public Task<GetImageLicenseListError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetImageLicenseListError.Create(response, ct);
}
