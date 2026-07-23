using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetKeywordsError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetKeywordsError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetKeywordsError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetKeywordsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetKeywordsError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 or 415 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetKeywordsErrorResponse : IErrorResponse<GetKeywordsError>
{
    public static GetKeywordsErrorResponse Instance { get; } = new();

    private GetKeywordsErrorResponse()
    {
    }

    public Task<GetKeywordsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetKeywordsError.Create(response, ct);
}
