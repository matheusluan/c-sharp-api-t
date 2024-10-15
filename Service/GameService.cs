namespace c_sharp_api_t.Service;
using c_sharp_api_t.DB;
using c_sharp_api_t.Models;
using Microsoft.EntityFrameworkCore;

public class GameService
{
    private readonly GameDb _dbContext;

    public GameService(GameDb dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Game>> GetAllGamesAsync()
    {
        return await _dbContext.Games.ToListAsync();
    }

    public async Task<List<Game>> GetActiveGamesAsync()
    {
        return await _dbContext.Games.Where(t => t.isActive).ToListAsync();
    }

    public async Task<Game?> GetGameByIdAsync(int id)
    {
        return await _dbContext.Games.FindAsync(id);
    }

    public async Task<Game> AddGameAsync(Game game)
    {
        _dbContext.Games.Add(game);
        await _dbContext.SaveChangesAsync();
        return game;
    }

    public async Task<bool> UpdateGameAsync(int id, Game inputGame)
    {
        var game = await _dbContext.Games.FindAsync(id);

        if (game == null)
            return false;

        game.Name = inputGame.Name;
        game.isActive = inputGame.isActive;
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteGameAsync(int id)
    {
        var game = await _dbContext.Games.FindAsync(id);
        if (game == null)
            return false;

        _dbContext.Games.Remove(game);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}
