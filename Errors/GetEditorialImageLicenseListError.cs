using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetEditorialImageLicenseListError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetEditorialImageLicenseListError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetEditorialImageLicenseListError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetEditorialImageLicenseListError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetEditorialImageLicenseListError> Create(HttpResponseMessage response,
        CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetEditorialImageLicenseListErrorResponse : IErrorResponse<GetEditorialImageLicenseListError>
{
    public static GetEditorialImageLicenseListErrorResponse Instance { get; } = new();

    private GetEditorialImageLicenseListErrorResponse()
    {
    }

    public Task<GetEditorialImageLicenseListError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetEditorialImageLicenseListError.Create(response, ct);
}
