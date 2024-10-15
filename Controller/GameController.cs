// Controllers/GameController.cs
using c_sharp_api_t.Models;
using c_sharp_api_t.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    private readonly GameService _gameService;

    public GameController(GameService gameService)
    {
        _gameService = gameService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Game>>> GetAllGames()
    {
        var games = await _gameService.GetAllGamesAsync();
        return Ok(games);
    }

    [HttpGet("active")]
    public async Task<ActionResult<List<Game>>> GetActiveGames()
    {
        var activeGames = await _gameService.GetActiveGamesAsync();
        return Ok(activeGames);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Game>> GetGameById(int id)
    {
        var game = await _gameService.GetGameByIdAsync(id);
        if (game == null) return NotFound();

        return Ok(game);
    }

    [HttpPost]
    public async Task<ActionResult<Game>> CreateGame(Game game)
    {
        var newGame = await _gameService.AddGameAsync(game);
        return CreatedAtAction(nameof(GetGameById), new { id = newGame.Id }, newGame);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGame(int id, Game inputGame)
    {
        var updated = await _gameService.UpdateGameAsync(id, inputGame);
        if (!updated) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGame(int id)
    {
        var deleted = await _gameService.DeleteGameAsync(id);
        if (!deleted) return NotFound();

        return NoContent();
    }
}