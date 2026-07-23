using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetContributorError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetContributorError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetContributorError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetContributorError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetContributorError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetContributorErrorResponse : IErrorResponse<GetContributorError>
{
    public static GetContributorErrorResponse Instance { get; } = new();

    private GetContributorErrorResponse()
    {
    }

    public Task<GetContributorError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetContributorError.Create(response, ct);
}
