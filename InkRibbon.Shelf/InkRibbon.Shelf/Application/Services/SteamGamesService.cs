using InkRibbon.Shelf.Domain.Dto;
using InkRibbon.Shelf.Domain.Interfaces.ApiClientService;
using InkRibbon.Shelf.Domain.Interfaces.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace InkRibbon.Shelf.Application.Services
{
    public class SteamGamesService : ISteamGamesService
    {
        private readonly ILogger<SteamGamesService> _logger;
        private readonly ISteamAppApiClient _steamAppClient;
        private readonly ISteamGamesApiClient _steamGamesClient;

        public SteamGamesService(ILogger<SteamGamesService> logger, ISteamAppApiClient steamAppClient, ISteamGamesApiClient steamGamesClient)
        {
            _logger = logger;
            _steamAppClient = steamAppClient;
            _steamGamesClient = steamGamesClient;
        }

        public async Task ConsumeGames()
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest", Port = 5672 };
                using (var connection = await factory.CreateConnectionAsync())
                using (var channel = await connection.CreateChannelAsync())
                {

                    await channel.QueueDeclareAsync(queue: "fila.teste",
                                                                    durable: true,
                                                                    exclusive: false,
                                                                    autoDelete: false,
                                                                    arguments: null);
                    await channel.BasicQosAsync(prefetchSize: 0, prefetchCount: 10, global: false);
                    var consumer = new AsyncEventingBasicConsumer(channel);
                    consumer.ReceivedAsync += async (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var mensagem = Encoding.UTF8.GetString(body);
                        var msg = JsonSerializer.Deserialize<Apps>(mensagem);

                        Console.WriteLine($"[x] Mensagem recebida: {mensagem}");
                        var game = await _steamGamesClient.GetVariableAsync($"/api/appdetails?appids={msg.appid}");
                        var a = game;
                        await channel.BasicAckAsync(deliveryTag: ea.DeliveryTag, multiple: false);
                    };

                    await channel.BasicConsumeAsync(queue: "fila.teste",
                                            autoAck: true,
                                            consumer: consumer);


                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task PublishGames()
        {
            try
            {
                var user = await _steamAppClient.GetAsync($"/ISteamApps/GetAppList/v2/");
                var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest", Port = 5672 };
                using (var connection = await factory.CreateConnectionAsync())
                using (var channel = await connection.CreateChannelAsync())
                {
                    await channel.QueueDeclareAsync(queue: "fila.teste",
                                                durable: true,
                                                exclusive: false,
                                                autoDelete: false,
                                                arguments: null);
                    var i = 0;
                    //while (i<=15)
                    //{
                    foreach (var g in user.applist.apps)
                    {
                        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(g));

                        await channel.BasicPublishAsync(exchange: "",
                                                    routingKey: "fila.teste",
                                                    body: body);
                        //_logger.LogInformation($"Messagem publicada Serilog {JsonSerializer.Serialize(g)}");
                    }
                    i++;
                    //}



                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
