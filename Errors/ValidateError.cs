using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class ValidateError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private ValidateError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static ValidateError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static ValidateError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<ValidateError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class ValidateErrorResponse : IErrorResponse<ValidateError>
{
    public static ValidateErrorResponse Instance { get; } = new();

    private ValidateErrorResponse()
    {
    }

    public Task<ValidateError> Map(HttpResponseMessage response, CancellationToken ct) =>
        ValidateError.Create(response, ct);
}
