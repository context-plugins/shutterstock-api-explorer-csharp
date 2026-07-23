using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class CreateAudioRendersError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private CreateAudioRendersError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static CreateAudioRendersError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static CreateAudioRendersError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<CreateAudioRendersError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class CreateAudioRendersErrorResponse : IErrorResponse<CreateAudioRendersError>
{
    public static CreateAudioRendersErrorResponse Instance { get; } = new();

    private CreateAudioRendersErrorResponse()
    {
    }

    public Task<CreateAudioRendersError> Map(HttpResponseMessage response, CancellationToken ct) =>
        CreateAudioRendersError.Create(response, ct);
}
