using System.Net.Http;
using ShutterstockApiExplorer.Api;
using ShutterstockApiExplorer.Core;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer;

/// <summary>
/// The Shutterstock API provides access to Shutterstock's library of media, as well as information about customers' accounts and the contributors that provide the media.
/// </summary>
public sealed class ShutterstockApiExplorerClient
{
    public ShutterstockApiExplorerClient(HttpClient httpClient, ShutterstockApiExplorerClientOptions options)
    {
        var server = new Server(options.Environment, options.Server);
        var queryParameterFactory = new QueryParameterFactory([]);
        var templateParamsFactory = new TemplateParamsFactory([]);
        var urlFactory = new UriFactory(queryParameterFactory, templateParamsFactory);
        var httpStatusPolicy = new HttpStatusPolicy([]);
        var headersFactory =
            new HeadersFactory([new HeaderParam("User-Agent", "ShutterstockApiExplorerClient/1.1.32 CSharp"),
                    new HeaderParam("X-APIMatic-Lang", "CSharp"),
                    new HeaderParam("X-APIMatic-Package-Version", "1.1.32"),
                    new HeaderParam("X-APIMatic-Gen-Version", "4.0.0"),
                    new HeaderParam("X-APIMatic-OS", RuntimeEnvironment.Os),
                    new HeaderParam("X-APIMatic-Runtime", RuntimeEnvironment.Runtime)]);
        var resiliencePipelineFactory = new ResiliencePipelineFactory(options.Retry);
        var rawClient =
            new RawClient(httpClient, urlFactory, httpStatusPolicy, headersFactory, resiliencePipelineFactory);
        var auth = new AuthSchemes(options, server, rawClient, urlFactory);
        AudioModel = new AudioModel(rawClient, server, auth);
        Catalog = new Catalog(rawClient, server, auth);
        ComputerVision = new ComputerVision(rawClient, server, auth);
        Contributors = new Contributors(rawClient, server, auth);
        CustomMusic = new CustomMusic(rawClient, server, auth);
        EditorialImages = new EditorialImages(rawClient, server, auth);
        EditorialVideo = new EditorialVideo(rawClient, server, auth);
        Images = new Images(rawClient, server, auth);
        Oauth = new Oauth(rawClient, server);
        SoundEffects = new SoundEffects(rawClient, server, auth);
        Test = new Test(rawClient, server);
        Users = new Users(rawClient, server, auth);
        Videos = new Videos(rawClient, server, auth);
    }

    public AudioModel AudioModel { get; }

    public Catalog Catalog { get; }

    public ComputerVision ComputerVision { get; }

    public Contributors Contributors { get; }

    public CustomMusic CustomMusic { get; }

    public EditorialImages EditorialImages { get; }

    public EditorialVideo EditorialVideo { get; }

    public Images Images { get; }

    public Oauth Oauth { get; }

    public SoundEffects SoundEffects { get; }

    public Test Test { get; }

    public Users Users { get; }

    public Videos Videos { get; }
}
