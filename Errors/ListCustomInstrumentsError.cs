using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class ListCustomInstrumentsError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private ListCustomInstrumentsError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static ListCustomInstrumentsError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static ListCustomInstrumentsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<ListCustomInstrumentsError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class ListCustomInstrumentsErrorResponse : IErrorResponse<ListCustomInstrumentsError>
{
    public static ListCustomInstrumentsErrorResponse Instance { get; } = new();

    private ListCustomInstrumentsErrorResponse()
    {
    }

    public Task<ListCustomInstrumentsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        ListCustomInstrumentsError.Create(response, ct);
}
