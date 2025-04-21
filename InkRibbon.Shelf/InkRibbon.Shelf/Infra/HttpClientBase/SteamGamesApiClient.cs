using InkRibbon.Shelf.Application.Services;
using InkRibbon.Shelf.Domain.Dto;
using InkRibbon.Shelf.Domain.Interfaces.ApiClientService;

namespace InkRibbon.Shelf.Infra.HttpClientBase
{
    public class SteamGamesApiClient : ServiceClientBase<Game, SteamGamesApiClient>, ISteamGamesApiClient
    {
        public SteamGamesApiClient(IHttpClientFactory clientFactory, ILogger<SteamGamesApiClient> logger, string clientName) : base(clientFactory, logger, clientName)
        {
        }
    }
}
