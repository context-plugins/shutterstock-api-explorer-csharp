using ShutterstockApiExplorer.Core;
using ShutterstockApiExplorer.Core.Authentication;
using ShutterstockApiExplorer.Core.Authentication.Basic;
using ShutterstockApiExplorer.Core.Authentication.OAuth2;
using ShutterstockApiExplorer.Core.Authentication.OAuth2.AuthorizationCode;

namespace ShutterstockApiExplorer;

internal sealed class AuthSchemes
{
    public IAuthScheme Basic { get; }
    public IAuthScheme CustomerAccessCode { get; }

    public AuthSchemes(ShutterstockApiExplorerClientOptions options,
        Server server,
        RawClient rawClient,
        UriFactory urlFactory)
    {
        Basic = BasicAuthScheme.Create(options.Basic);
        CustomerAccessCode =
            OAuth2RefreshableScheme<OAuth2AuthorizationCodeCredentials>.Create(options.CustomerAccessCode,
                options.CustomerAccessCodeTokenStrategy ??
                    OAuth2AuthorizationCodeStrategy.ForBasicAuthRequest(server.AuthServer("/authorize"),
                        server.Default("/v2/oauth/access_token"),
                        rawClient,
                        urlFactory));
    }
}
