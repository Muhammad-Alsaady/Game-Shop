namespace Game_Shop.UI.Services.Repositroy
{
    public interface IGameRepository
    {
        public IEnumerable<Game> GetGames();
        public Game? GetGameById(int? id);
        public Task<bool> DeleteGame(Game gameModel);
        public Task Create(CreateGameViewModel gameModel);
        public Task<Game?> Update(EditGameViewModel gameModel);

    }
}
