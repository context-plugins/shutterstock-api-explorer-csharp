using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetEditorialVideoLicenseListError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetEditorialVideoLicenseListError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetEditorialVideoLicenseListError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetEditorialVideoLicenseListError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetEditorialVideoLicenseListError> Create(HttpResponseMessage response,
        CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetEditorialVideoLicenseListErrorResponse : IErrorResponse<GetEditorialVideoLicenseListError>
{
    public static GetEditorialVideoLicenseListErrorResponse Instance { get; } = new();

    private GetEditorialVideoLicenseListErrorResponse()
    {
    }

    public Task<GetEditorialVideoLicenseListError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetEditorialVideoLicenseListError.Create(response, ct);
}
