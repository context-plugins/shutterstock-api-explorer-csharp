using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class ListImageCategoriesError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private ListImageCategoriesError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static ListImageCategoriesError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static ListImageCategoriesError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<ListImageCategoriesError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class ListImageCategoriesErrorResponse : IErrorResponse<ListImageCategoriesError>
{
    public static ListImageCategoriesErrorResponse Instance { get; } = new();

    private ListImageCategoriesErrorResponse()
    {
    }

    public Task<ListImageCategoriesError> Map(HttpResponseMessage response, CancellationToken ct) =>
        ListImageCategoriesError.Create(response, ct);
}
