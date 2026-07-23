using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetCollectionsError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetCollectionsError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetCollectionsError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetCollectionsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetCollectionsError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetCollectionsErrorResponse : IErrorResponse<GetCollectionsError>
{
    public static GetCollectionsErrorResponse Instance { get; } = new();

    private GetCollectionsErrorResponse()
    {
    }

    public Task<GetCollectionsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetCollectionsError.Create(response, ct);
}
