using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetEditorialCategoriesError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetEditorialCategoriesError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetEditorialCategoriesError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetEditorialCategoriesError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetEditorialCategoriesError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetEditorialCategoriesErrorResponse : IErrorResponse<GetEditorialCategoriesError>
{
    public static GetEditorialCategoriesErrorResponse Instance { get; } = new();

    private GetEditorialCategoriesErrorResponse()
    {
    }

    public Task<GetEditorialCategoriesError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetEditorialCategoriesError.Create(response, ct);
}
