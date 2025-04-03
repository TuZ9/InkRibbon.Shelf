using InkRibbon.Shelf.Domain.Interfaces.Services;

namespace InkRibbon.Shelf.Infra.Extensions
{
    public static class HangireJobs
    {
        public static async void RunHangFireJob(ServiceProvider services)
        {
            await RunJobs(services);
        }
        public static async Task RunJobs(ServiceProvider services)
        {
            using var scope = services.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<ISteamGamesService>();
            await service.PublishGames();
            //BackgroundJob.Enqueue(() => service.BuildBase());
        }
    }
}
