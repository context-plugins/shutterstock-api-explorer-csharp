using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetEditorialVideoError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetEditorialVideoError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetEditorialVideoError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetEditorialVideoError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetEditorialVideoError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 or 406 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetEditorialVideoErrorResponse : IErrorResponse<GetEditorialVideoError>
{
    public static GetEditorialVideoErrorResponse Instance { get; } = new();

    private GetEditorialVideoErrorResponse()
    {
    }

    public Task<GetEditorialVideoError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetEditorialVideoError.Create(response, ct);
}
