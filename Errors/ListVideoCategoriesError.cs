using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class ListVideoCategoriesError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private ListVideoCategoriesError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static ListVideoCategoriesError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static ListVideoCategoriesError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<ListVideoCategoriesError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class ListVideoCategoriesErrorResponse : IErrorResponse<ListVideoCategoriesError>
{
    public static ListVideoCategoriesErrorResponse Instance { get; } = new();

    private ListVideoCategoriesErrorResponse()
    {
    }

    public Task<ListVideoCategoriesError> Map(HttpResponseMessage response, CancellationToken ct) =>
        ListVideoCategoriesError.Create(response, ct);
}
