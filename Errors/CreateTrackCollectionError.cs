using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class CreateTrackCollectionError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private CreateTrackCollectionError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static CreateTrackCollectionError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static CreateTrackCollectionError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<CreateTrackCollectionError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class CreateTrackCollectionErrorResponse : IErrorResponse<CreateTrackCollectionError>
{
    public static CreateTrackCollectionErrorResponse Instance { get; } = new();

    private CreateTrackCollectionErrorResponse()
    {
    }

    public Task<CreateTrackCollectionError> Map(HttpResponseMessage response, CancellationToken ct) =>
        CreateTrackCollectionError.Create(response, ct);
}
