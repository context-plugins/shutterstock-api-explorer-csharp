using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ShutterstockApiExplorer;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddShutterstockApiExplorerClient(Action<ShutterstockApiExplorerClientOptions>? configure = null)
        {
            var options = new ShutterstockApiExplorerClientOptions();
            configure?.Invoke(options);
            services.AddHttpClient();
            services.AddSingleton(sp =>
                {
                    var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
                    var httpClient = httpClientFactory.CreateClient();
                    return new ShutterstockApiExplorerClient(httpClient, options);
                });
            return services;
        }
    }
}
