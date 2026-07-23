using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetTrackLicenseListError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetTrackLicenseListError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetTrackLicenseListError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetTrackLicenseListError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetTrackLicenseListError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetTrackLicenseListErrorResponse : IErrorResponse<GetTrackLicenseListError>
{
    public static GetTrackLicenseListErrorResponse Instance { get; } = new();

    private GetTrackLicenseListErrorResponse()
    {
    }

    public Task<GetTrackLicenseListError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetTrackLicenseListError.Create(response, ct);
}
