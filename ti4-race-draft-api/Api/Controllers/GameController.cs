using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ti4_race_draft_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        public GameController()
        {

        }

        [HttpPost]
        public async Task<IActionResult> Create(string[] names)
        {
            return Ok();
        }
    }
}
