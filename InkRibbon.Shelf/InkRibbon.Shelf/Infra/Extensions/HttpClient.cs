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

            //services.AddHttpClient<ISteamGamesApiClient, SteamGamesApiClient>(_ => _.BaseAddress = new Uri(RunTimeConfig.SteamEndpoint));

            services.AddHttpClient("Steam",
               client => { client.BaseAddress = new Uri(RunTimeConfig.SteamEndpoint); });

            services.AddSingleton<ISteamGamesApiClient, SteamGamesApiClient>(x =>
                new SteamGamesApiClient(x.GetService<IHttpClientFactory>()!, steamLogger, "Steam"));

            return services;
        }
    }
}