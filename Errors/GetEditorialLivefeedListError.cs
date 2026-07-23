using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetEditorialLivefeedListError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetEditorialLivefeedListError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetEditorialLivefeedListError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetEditorialLivefeedListError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetEditorialLivefeedListError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 or 406 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetEditorialLivefeedListErrorResponse : IErrorResponse<GetEditorialLivefeedListError>
{
    public static GetEditorialLivefeedListErrorResponse Instance { get; } = new();

    private GetEditorialLivefeedListErrorResponse()
    {
    }

    public Task<GetEditorialLivefeedListError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetEditorialLivefeedListError.Create(response, ct);
}
