using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class RenameVideoCollectionError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private RenameVideoCollectionError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static RenameVideoCollectionError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static RenameVideoCollectionError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<RenameVideoCollectionError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 or 404 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class RenameVideoCollectionErrorResponse : IErrorResponse<RenameVideoCollectionError>
{
    public static RenameVideoCollectionErrorResponse Instance { get; } = new();

    private RenameVideoCollectionErrorResponse()
    {
    }

    public Task<RenameVideoCollectionError> Map(HttpResponseMessage response, CancellationToken ct) =>
        RenameVideoCollectionError.Create(response, ct);
}
