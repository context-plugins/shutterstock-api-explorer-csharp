using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetImageSuggestionsError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetImageSuggestionsError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetImageSuggestionsError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetImageSuggestionsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetImageSuggestionsError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetImageSuggestionsErrorResponse : IErrorResponse<GetImageSuggestionsError>
{
    public static GetImageSuggestionsErrorResponse Instance { get; } = new();

    private GetImageSuggestionsErrorResponse()
    {
    }

    public Task<GetImageSuggestionsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetImageSuggestionsError.Create(response, ct);
}
