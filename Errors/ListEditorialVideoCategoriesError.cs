using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class ListEditorialVideoCategoriesError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private ListEditorialVideoCategoriesError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static ListEditorialVideoCategoriesError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static ListEditorialVideoCategoriesError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<ListEditorialVideoCategoriesError> Create(HttpResponseMessage response,
        CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class ListEditorialVideoCategoriesErrorResponse : IErrorResponse<ListEditorialVideoCategoriesError>
{
    public static ListEditorialVideoCategoriesErrorResponse Instance { get; } = new();

    private ListEditorialVideoCategoriesErrorResponse()
    {
    }

    public Task<ListEditorialVideoCategoriesError> Map(HttpResponseMessage response, CancellationToken ct) =>
        ListEditorialVideoCategoriesError.Create(response, ct);
}
