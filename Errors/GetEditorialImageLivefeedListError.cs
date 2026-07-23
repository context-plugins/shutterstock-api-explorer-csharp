using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetEditorialImageLivefeedListError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetEditorialImageLivefeedListError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetEditorialImageLivefeedListError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetEditorialImageLivefeedListError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetEditorialImageLivefeedListError> Create(HttpResponseMessage response,
        CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 or 404 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetEditorialImageLivefeedListErrorResponse : IErrorResponse<GetEditorialImageLivefeedListError>
{
    public static GetEditorialImageLivefeedListErrorResponse Instance { get; } = new();

    private GetEditorialImageLivefeedListErrorResponse()
    {
    }

    public Task<GetEditorialImageLivefeedListError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetEditorialImageLivefeedListError.Create(response, ct);
}
