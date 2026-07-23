using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetVideoLicenseListError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetVideoLicenseListError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetVideoLicenseListError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetVideoLicenseListError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetVideoLicenseListError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetVideoLicenseListErrorResponse : IErrorResponse<GetVideoLicenseListError>
{
    public static GetVideoLicenseListErrorResponse Instance { get; } = new();

    private GetVideoLicenseListErrorResponse()
    {
    }

    public Task<GetVideoLicenseListError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetVideoLicenseListError.Create(response, ct);
}
