using ConferenceManager.Service;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManager.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class SpeakerController(ISpeakerService SpeakerService) : ControllerBase
    {
        private readonly ISpeakerService _SpeakerService = SpeakerService;

        [HttpGet]
        public IActionResult GetSpeakers()
        {
            return Ok(_SpeakerService.GetAllSpeakers());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetSpeakerById(int id)
        {
            return Ok(_SpeakerService.GetSpeaker(id));
        }
    }
}
