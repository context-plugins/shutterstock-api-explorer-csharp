using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class CreateVideoCollectionError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private CreateVideoCollectionError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static CreateVideoCollectionError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static CreateVideoCollectionError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<CreateVideoCollectionError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class CreateVideoCollectionErrorResponse : IErrorResponse<CreateVideoCollectionError>
{
    public static CreateVideoCollectionErrorResponse Instance { get; } = new();

    private CreateVideoCollectionErrorResponse()
    {
    }

    public Task<CreateVideoCollectionError> Map(HttpResponseMessage response, CancellationToken ct) =>
        CreateVideoCollectionError.Create(response, ct);
}
