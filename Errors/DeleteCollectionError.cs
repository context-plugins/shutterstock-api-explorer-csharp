using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class DeleteCollectionError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private DeleteCollectionError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static DeleteCollectionError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static DeleteCollectionError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<DeleteCollectionError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            404 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class DeleteCollectionErrorResponse : IErrorResponse<DeleteCollectionError>
{
    public static DeleteCollectionErrorResponse Instance { get; } = new();

    private DeleteCollectionErrorResponse()
    {
    }

    public Task<DeleteCollectionError> Map(HttpResponseMessage response, CancellationToken ct) =>
        DeleteCollectionError.Create(response, ct);
}
