using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Errors;

public sealed class GetContributorCollectionItemsError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetContributorCollectionItemsError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetContributorCollectionItemsError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetContributorCollectionItemsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetContributorCollectionItemsError> Create(HttpResponseMessage response,
        CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 or 404 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetContributorCollectionItemsErrorResponse : IErrorResponse<GetContributorCollectionItemsError>
{
    public static GetContributorCollectionItemsErrorResponse Instance { get; } = new();

    private GetContributorCollectionItemsErrorResponse()
    {
    }

    public Task<GetContributorCollectionItemsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetContributorCollectionItemsError.Create(response, ct);
}
