using System.Net.Http;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Core.Request;

internal sealed class BinaryRequest : IRequest
{
    private readonly BinaryContent _binaryContent;

    private BinaryRequest(BinaryContent binaryContent) => _binaryContent = binaryContent;

    public static BinaryRequest Create(BinaryContent binaryContent) =>
        new(binaryContent);

    public HttpContent Get()
    {
        var content = new StreamContent(new NonDisposingStream(_binaryContent.Stream));
        content.Headers.ContentType = _binaryContent.ContentType;
        return content;
    }

    public bool CanRetry => false;
}
