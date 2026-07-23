using System.Net.Http;

namespace ShutterstockApiExplorer.Core.Request;

internal interface IRequest
{
    HttpContent Get();

    bool CanRetry { get; }
}