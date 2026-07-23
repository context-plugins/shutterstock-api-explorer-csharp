using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetEditorialImageError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetEditorialImageError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetEditorialImageError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetEditorialImageError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetEditorialImageError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 or 404 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetEditorialImageErrorResponse : IErrorResponse<GetEditorialImageError>
{
    public static GetEditorialImageErrorResponse Instance { get; } = new();

    private GetEditorialImageErrorResponse()
    {
    }

    public Task<GetEditorialImageError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetEditorialImageError.Create(response, ct);
}
