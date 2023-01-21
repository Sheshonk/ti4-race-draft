using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ti4_race_draft_api.DTO;
using ti4_race_draft_api.Services;

namespace ti4_race_draft_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(PlayerClaim claim)
        {
            return Ok(await _playerService.ClaimPlayer(claim));
        }

        [HttpDelete("")]
        public async Task<IActionResult> Delete(PlayerUnclaim unclaim)
        {
            try
            {
                await _playerService.UnclaimPlayer(unclaim);
                return Ok();
            }
            catch (AccessViolationException ex)
            {
                return Unauthorized();
            }
        }
    }
}
