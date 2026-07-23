using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetImageListError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetImageListError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetImageListError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetImageListError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetImageListError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetImageListErrorResponse : IErrorResponse<GetImageListError>
{
    public static GetImageListErrorResponse Instance { get; } = new();

    private GetImageListErrorResponse()
    {
    }

    public Task<GetImageListError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetImageListError.Create(response, ct);
}
