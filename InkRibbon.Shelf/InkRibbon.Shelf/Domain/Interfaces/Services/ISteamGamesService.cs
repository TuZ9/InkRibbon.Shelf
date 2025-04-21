
namespace InkRibbon.Shelf.Domain.Interfaces.Services
{
    public interface ISteamGamesService
    {
        Task UpdateGames();
        Task ConsumeGames();
        Task PublishGames();
    }
}