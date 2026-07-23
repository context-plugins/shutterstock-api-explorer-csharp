using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetVideoSuggestionsError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetVideoSuggestionsError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetVideoSuggestionsError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetVideoSuggestionsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetVideoSuggestionsError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetVideoSuggestionsErrorResponse : IErrorResponse<GetVideoSuggestionsError>
{
    public static GetVideoSuggestionsErrorResponse Instance { get; } = new();

    private GetVideoSuggestionsErrorResponse()
    {
    }

    public Task<GetVideoSuggestionsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetVideoSuggestionsError.Create(response, ct);
}
