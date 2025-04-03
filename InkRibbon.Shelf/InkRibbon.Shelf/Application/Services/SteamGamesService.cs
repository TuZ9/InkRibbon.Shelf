using InkRibbon.Shelf.Application.Static;
using InkRibbon.Shelf.Domain.Dto;
using InkRibbon.Shelf.Domain.Entities;
using InkRibbon.Shelf.Domain.Interfaces.ApiClientService;
using InkRibbon.Shelf.Domain.Interfaces.Services;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace InkRibbon.Shelf.Application.Services
{
    public class SteamGamesService : ISteamGamesService
    {
        private readonly ILogger<SteamGamesService> _logger;
        private readonly ISteamGamesApiClient _steamClient;

        public SteamGamesService(ILogger<SteamGamesService> logger, ISteamGamesApiClient steamClient)
        {
            _logger = logger;
            _steamClient = steamClient;
        }

        public async Task PublishGames()
        {
            try
            {
                var user = await _steamClient.GetAsync($"/ISteamApps/GetAppList/v2/");
                var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest", Port = 5672 };
                using (var connection = await factory.CreateConnectionAsync())

                using (var channel = await connection.CreateChannelAsync())
                {
                    await channel.QueueDeclareAsync(queue: "fila.teste",
                                                durable: true,
                                                exclusive: false,
                                                autoDelete: false,
                                                arguments: null);
                    foreach (var g in user.applist.apps)
                    {
                        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(g));

                        await channel.BasicPublishAsync(exchange: "",
                                                    routingKey: "fila.teste",
                                                    body: body);
                        _logger.LogInformation($"Messagem publicada Serilog {JsonSerializer.Serialize(g)}");
                    }
                }


            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
