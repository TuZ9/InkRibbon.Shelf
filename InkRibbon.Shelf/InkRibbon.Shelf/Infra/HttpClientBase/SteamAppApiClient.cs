using InkRibbon.Shelf.Application.Services;
using InkRibbon.Shelf.Domain.Dto;
using InkRibbon.Shelf.Domain.Interfaces.ApiClientService;

namespace InkRibbon.Shelf.Infra.HttpClientBase
{
    public class SteamAppApiClient : ServiceClientBase<AppDto, SteamAppApiClient>, ISteamAppApiClient
    {
        public SteamAppApiClient(IHttpClientFactory clientFactory, ILogger<SteamAppApiClient> logger, string clientName) : base(clientFactory, logger, clientName)
        {
        }
    }
}
