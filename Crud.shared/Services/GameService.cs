using Crud.shared.Data;
using Crud.shared.Entity;
using Crud.shared.Services;
using Microsoft.EntityFrameworkCore;

namespace Crud.shared.Services;

public class GameService : IGameService
{
    private readonly DataContext _context;

    public GameService(DataContext context)
    {
        _context = context;
    }
    public async Task<List<Game>> GetAllGames()
    {
        var games = await _context.Games.ToListAsync();
        return games;

    }

    public Task<Game> Add(Game game)
    {
        _context.Games.Add(game);
        _context.SaveChanges();

        return Task.FromResult(game);
    }

    public Task<Game> GetById(int id)
    {
        var game = _context.Games.Find(id);
        return Task.FromResult(game);
    }

    public Task<Game> Edit(int id, Game game)
    {
        var dbGame = _context.Games.Find(id);
        if (dbGame != null)
        {
            dbGame.Name = game.Name;
            _context.SaveChanges();
            return Task.FromResult(dbGame);
        }

        throw new Exception("Game not found");
    }

        public Task<bool> Delete(int id)
    {
        var dbGame = _context.Games.Find(id);
        if (dbGame != null)
        {
            _context.Remove(dbGame);
            _context.SaveChanges();
            return Task.FromResult(true);
        }

        return Task.FromResult(false);
    }
}
