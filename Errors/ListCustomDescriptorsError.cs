using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class ListCustomDescriptorsError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private ListCustomDescriptorsError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static ListCustomDescriptorsError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static ListCustomDescriptorsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<ListCustomDescriptorsError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 or 404 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class ListCustomDescriptorsErrorResponse : IErrorResponse<ListCustomDescriptorsError>
{
    public static ListCustomDescriptorsErrorResponse Instance { get; } = new();

    private ListCustomDescriptorsErrorResponse()
    {
    }

    public Task<ListCustomDescriptorsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        ListCustomDescriptorsError.Create(response, ct);
}
