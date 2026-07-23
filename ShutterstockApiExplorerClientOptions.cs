using ShutterstockApiExplorer.Core.Authentication.Basic;
using ShutterstockApiExplorer.Core.Authentication.OAuth2;
using ShutterstockApiExplorer.Core.Authentication.OAuth2.AuthorizationCode;
using ShutterstockApiExplorer.Core.Configuration;
using ShutterstockApiExplorer.Servers;

namespace ShutterstockApiExplorer;

public class ShutterstockApiExplorerClientOptions
{
    public ServerEnvironment Environment { get; set; } = ServerEnvironment.Default();
    public RetryOptions Retry { get; set; } = RetryOptions.Default();
    public ServerOptions Server { get; set; } = new();
    public BasicAuthCredentials? Basic { get; set; }
    public OAuth2AuthorizationCodeCredentials? CustomerAccessCode { get; set; }
    public IOAuth2RefreshableTokenStrategy<OAuth2AuthorizationCodeCredentials>? CustomerAccessCodeTokenStrategy { get; set; }
}
