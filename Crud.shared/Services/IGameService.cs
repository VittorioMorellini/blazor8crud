using Crud.shared.Entity;

namespace Crud.shared.Services
{
    public interface IGameService
    {
        Task<List<Game>> GetAllGames();
        Task<Game> Add(Game game);
        Task<Game> GetById(int id);
        Task<Game> Edit(int id, Game game);
        Task<bool> Delete(int id);
    }
}
