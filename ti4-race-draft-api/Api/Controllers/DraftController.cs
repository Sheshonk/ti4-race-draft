using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ti4_race_draft_api.DTO;
using ti4_race_draft_api.Services;

namespace ti4_race_draft_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DraftController : ControllerBase
    {
        private readonly IDraftService _draftService;

        public DraftController(IDraftService draftService)
        {
            _draftService = draftService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(DraftPick draft)
        {
            try
            {
                await _draftService.Create(draft);
                return Ok();
            }
            catch (AccessViolationException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
