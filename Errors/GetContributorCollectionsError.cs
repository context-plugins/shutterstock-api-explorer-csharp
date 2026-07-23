using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetContributorCollectionsError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetContributorCollectionsError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetContributorCollectionsError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetContributorCollectionsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetContributorCollectionsError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 or 404 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetContributorCollectionsErrorResponse : IErrorResponse<GetContributorCollectionsError>
{
    public static GetContributorCollectionsErrorResponse Instance { get; } = new();

    private GetContributorCollectionsErrorResponse()
    {
    }

    public Task<GetContributorCollectionsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetContributorCollectionsError.Create(response, ct);
}
