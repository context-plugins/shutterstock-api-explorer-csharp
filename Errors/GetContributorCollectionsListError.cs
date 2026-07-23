using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetContributorCollectionsListError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetContributorCollectionsListError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetContributorCollectionsListError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetContributorCollectionsListError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetContributorCollectionsListError> Create(HttpResponseMessage response,
        CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 or 404 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetContributorCollectionsListErrorResponse : IErrorResponse<GetContributorCollectionsListError>
{
    public static GetContributorCollectionsListErrorResponse Instance { get; } = new();

    private GetContributorCollectionsListErrorResponse()
    {
    }

    public Task<GetContributorCollectionsListError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetContributorCollectionsListError.Create(response, ct);
}
