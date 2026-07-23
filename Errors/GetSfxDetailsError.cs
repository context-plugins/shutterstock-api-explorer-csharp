using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetSfxDetailsError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetSfxDetailsError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetSfxDetailsError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetSfxDetailsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetSfxDetailsError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetSfxDetailsErrorResponse : IErrorResponse<GetSfxDetailsError>
{
    public static GetSfxDetailsErrorResponse Instance { get; } = new();

    private GetSfxDetailsErrorResponse()
    {
    }

    public Task<GetSfxDetailsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetSfxDetailsError.Create(response, ct);
}
