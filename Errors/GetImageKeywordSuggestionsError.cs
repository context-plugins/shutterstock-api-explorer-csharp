using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetImageKeywordSuggestionsError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetImageKeywordSuggestionsError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetImageKeywordSuggestionsError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetImageKeywordSuggestionsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetImageKeywordSuggestionsError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetImageKeywordSuggestionsErrorResponse : IErrorResponse<GetImageKeywordSuggestionsError>
{
    public static GetImageKeywordSuggestionsErrorResponse Instance { get; } = new();

    private GetImageKeywordSuggestionsErrorResponse()
    {
    }

    public Task<GetImageKeywordSuggestionsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetImageKeywordSuggestionsError.Create(response, ct);
}
