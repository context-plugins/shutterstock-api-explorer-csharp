using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class RenameImageCollectionError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private RenameImageCollectionError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static RenameImageCollectionError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static RenameImageCollectionError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<RenameImageCollectionError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 or 404 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class RenameImageCollectionErrorResponse : IErrorResponse<RenameImageCollectionError>
{
    public static RenameImageCollectionErrorResponse Instance { get; } = new();

    private RenameImageCollectionErrorResponse()
    {
    }

    public Task<RenameImageCollectionError> Map(HttpResponseMessage response, CancellationToken ct) =>
        RenameImageCollectionError.Create(response, ct);
}
