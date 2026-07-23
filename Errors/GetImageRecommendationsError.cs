using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetImageRecommendationsError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetImageRecommendationsError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetImageRecommendationsError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetImageRecommendationsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetImageRecommendationsError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetImageRecommendationsErrorResponse : IErrorResponse<GetImageRecommendationsError>
{
    public static GetImageRecommendationsErrorResponse Instance { get; } = new();

    private GetImageRecommendationsErrorResponse()
    {
    }

    public Task<GetImageRecommendationsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetImageRecommendationsError.Create(response, ct);
}
