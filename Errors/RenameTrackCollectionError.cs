using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class RenameTrackCollectionError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private RenameTrackCollectionError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static RenameTrackCollectionError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static RenameTrackCollectionError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<RenameTrackCollectionError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 or 404 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class RenameTrackCollectionErrorResponse : IErrorResponse<RenameTrackCollectionError>
{
    public static RenameTrackCollectionErrorResponse Instance { get; } = new();

    private RenameTrackCollectionErrorResponse()
    {
    }

    public Task<RenameTrackCollectionError> Map(HttpResponseMessage response, CancellationToken ct) =>
        RenameTrackCollectionError.Create(response, ct);
}
