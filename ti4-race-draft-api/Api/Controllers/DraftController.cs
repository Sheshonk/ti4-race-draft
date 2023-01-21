using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ti4_race_draft_api.DTO;

namespace ti4_race_draft_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DraftController : ControllerBase
    {
        public DraftController()
        {

        }

        [HttpPost]
        public async Task<IActionResult> Create(Draft draft)
        {
            //make sure races belong to player
            //make sure auth token belongs to player
            throw new NotImplementedException();
        }
    }
}
