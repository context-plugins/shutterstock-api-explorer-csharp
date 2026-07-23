using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetImageCollectionListError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetImageCollectionListError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetImageCollectionListError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetImageCollectionListError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetImageCollectionListError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetImageCollectionListErrorResponse : IErrorResponse<GetImageCollectionListError>
{
    public static GetImageCollectionListErrorResponse Instance { get; } = new();

    private GetImageCollectionListErrorResponse()
    {
    }

    public Task<GetImageCollectionListError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetImageCollectionListError.Create(response, ct);
}
