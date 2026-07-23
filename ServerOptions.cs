using ShutterstockApiExplorer.Servers;

namespace ShutterstockApiExplorer;

public class ServerOptions
{
    public DefaultOptions Default { get; set; } = new();
    public AuthServerOptions AuthServer { get; set; } = new();
}
