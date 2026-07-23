using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class CreateImageCollectionError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private CreateImageCollectionError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static CreateImageCollectionError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static CreateImageCollectionError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<CreateImageCollectionError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class CreateImageCollectionErrorResponse : IErrorResponse<CreateImageCollectionError>
{
    public static CreateImageCollectionErrorResponse Instance { get; } = new();

    private CreateImageCollectionErrorResponse()
    {
    }

    public Task<CreateImageCollectionError> Map(HttpResponseMessage response, CancellationToken ct) =>
        CreateImageCollectionError.Create(response, ct);
}
