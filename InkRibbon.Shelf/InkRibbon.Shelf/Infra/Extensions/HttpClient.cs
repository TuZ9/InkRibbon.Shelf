using InkRibbon.Shelf.Application.Static;
using InkRibbon.Shelf.Domain.Interfaces.ApiClientService;
using InkRibbon.Shelf.Infra.HttpClientBase;

namespace InkRibbon.Shelf.Infra.Extensions
{
    public static class HttpClient
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();

            var steamLogger = serviceProvider.GetService(typeof(ILogger<SteamGamesApiClient>)) as ILogger<SteamGamesApiClient>;
            var appLogger = serviceProvider.GetService(typeof(ILogger<SteamAppApiClient>)) as ILogger<SteamAppApiClient>;
            
            services.AddHttpClient("Steam",
               client => { client.BaseAddress = new Uri(RunTimeConfig.SteamEndpoint); });
            services.AddHttpClient("SteamGame",
               client => { client.BaseAddress = new Uri(RunTimeConfig.SteamEndpointGame); });

            services.AddHttpClient("SteamStore",
               client => { client.BaseAddress = new Uri(RunTimeConfig.SteamEndpointGame); });

            services.AddSingleton<ISteamGamesApiClient, SteamGamesApiClient>(x =>
                new SteamGamesApiClient(x.GetService<IHttpClientFactory>()!, steamLogger, "SteamStore"));

            services.AddSingleton<ISteamAppApiClient, SteamAppApiClient>(x =>
                new SteamAppApiClient(x.GetService<IHttpClientFactory>()!, appLogger, "Steam"));

            return services;
        }
    }
}