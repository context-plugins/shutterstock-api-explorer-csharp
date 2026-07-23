using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetUserSubscriptionListError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetUserSubscriptionListError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetUserSubscriptionListError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetUserSubscriptionListError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetUserSubscriptionListError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetUserSubscriptionListErrorResponse : IErrorResponse<GetUserSubscriptionListError>
{
    public static GetUserSubscriptionListErrorResponse Instance { get; } = new();

    private GetUserSubscriptionListErrorResponse()
    {
    }

    public Task<GetUserSubscriptionListError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetUserSubscriptionListError.Create(response, ct);
}
