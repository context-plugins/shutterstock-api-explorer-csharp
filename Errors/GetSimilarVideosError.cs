using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetSimilarVideosError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetSimilarVideosError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetSimilarVideosError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetSimilarVideosError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetSimilarVideosError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetSimilarVideosErrorResponse : IErrorResponse<GetSimilarVideosError>
{
    public static GetSimilarVideosErrorResponse Instance { get; } = new();

    private GetSimilarVideosErrorResponse()
    {
    }

    public Task<GetSimilarVideosError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetSimilarVideosError.Create(response, ct);
}
