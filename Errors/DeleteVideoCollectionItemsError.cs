using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class DeleteVideoCollectionItemsError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private DeleteVideoCollectionItemsError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static DeleteVideoCollectionItemsError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static DeleteVideoCollectionItemsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<DeleteVideoCollectionItemsError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 or 404 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class DeleteVideoCollectionItemsErrorResponse : IErrorResponse<DeleteVideoCollectionItemsError>
{
    public static DeleteVideoCollectionItemsErrorResponse Instance { get; } = new();

    private DeleteVideoCollectionItemsErrorResponse()
    {
    }

    public Task<DeleteVideoCollectionItemsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        DeleteVideoCollectionItemsError.Create(response, ct);
}
