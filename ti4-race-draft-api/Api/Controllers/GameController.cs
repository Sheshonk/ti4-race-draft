using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ti4_race_draft_api.Services;

namespace ti4_race_draft_api.Controllers
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

        [HttpPost]
        public async Task<IActionResult> Create(string[] names)
        {
            return Ok(await _gameService.Create(names));
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid publicToken)
        {
            throw new NotImplementedException();
        }
    }
}