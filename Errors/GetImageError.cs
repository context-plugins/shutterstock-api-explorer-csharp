using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetImageError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetImageError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetImageError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetImageError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetImageError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetImageErrorResponse : IErrorResponse<GetImageError>
{
    public static GetImageErrorResponse Instance { get; } = new();

    private GetImageErrorResponse()
    {
    }

    public Task<GetImageError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetImageError.Create(response, ct);
}
