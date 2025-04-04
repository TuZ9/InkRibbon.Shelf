using InkRibbon.Shelf.Application.Services;
using InkRibbon.Shelf.Domain.Interfaces.Repositories;
using InkRibbon.Shelf.Domain.Interfaces.Services;
using InkRibbon.Shelf.Infra.Context;
using InkRibbon.Shelf.Infra.Repositories.Postgres;

namespace InkRibbon.Shelf.Infra.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .RegisterServices();
        }

        private static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            return services
                .AddScoped(_ => new AuroraDbContext())
                .AddScoped<IUserRepository, UserRepository>()
                .AddSingleton<ISteamGamesService, SteamGamesService>();
        }
    }
}
