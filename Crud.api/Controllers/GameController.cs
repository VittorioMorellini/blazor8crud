using Crud.shared.Entity;
using Crud.shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> Edit(int id)
        {
            var game = await _gameService.GetById(id);
            return Ok(game);
        }
        
        [HttpPost]
        public async Task<ActionResult<Game>> Add(Game game)
        {
            var addedGame = await _gameService.Add(game);
            return Ok(addedGame);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Game>> Edit(int id, Game game)
        {
            var updatedGame = await _gameService.Edit(id, game);
            return Ok(updatedGame);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var deleted= await _gameService.Delete(id);
            return Ok(deleted);
        }
    }
}
