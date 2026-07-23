using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetContributorListError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetContributorListError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetContributorListError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetContributorListError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetContributorListError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetContributorListErrorResponse : IErrorResponse<GetContributorListError>
{
    public static GetContributorListErrorResponse Instance { get; } = new();

    private GetContributorListErrorResponse()
    {
    }

    public Task<GetContributorListError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetContributorListError.Create(response, ct);
}
