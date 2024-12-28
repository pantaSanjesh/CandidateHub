using CandidateHubAPI.Dtos;
using CandidateHubAPI.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CandidateHubAPI.Controllers
{
    [ApiController]
    [Route("api/candidates")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _service;

        public CandidateController(ICandidateService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateCandidate([FromBody] CandidateDto candidateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _service.AddOrUpdateCandidateAsync(candidateDto);
            return Ok("Candidate information added/updated successfully.");
        }
    }

}
