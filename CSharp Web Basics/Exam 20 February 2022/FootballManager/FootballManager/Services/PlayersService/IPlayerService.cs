namespace FootballManager.Services.PlayersService
{
    using System.Collections.Generic;

    using FootballManager.ViewModels.Players;

    public interface IPlayerService
    {
        (ICollection<string>, ICollection<AllPlayerViewModel>) AllPlayers();

        (ICollection<string>, ICollection<AllPlayerViewModel>) MyPlayers(string userId);

        ICollection<string> AddPlayer(AddPlayerViewModel model, string userId);

        ICollection<string> AddPlayerToCollection(string playerId, string userId);

        ICollection<string> DeletePlayerFromCollection(string playerId, string userId);
    }
}
