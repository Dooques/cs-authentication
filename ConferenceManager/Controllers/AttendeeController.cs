using ConferenceManager.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManager.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AttendeesController(IAttendeeService attendeeService) : ControllerBase
    {
        private readonly IAttendeeService _AttendeeService = attendeeService;

        [HttpGet]
        public IActionResult GetAttendees()
        {
            return Ok(_AttendeeService.GetAllAttendees());
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize()]
        public IActionResult GetAttendeeById(string id)
        {
            Request.Headers.TryGetValue("userId", out var idHeader);
            return Ok(_AttendeeService.GetAttendee(id, idHeader));
        }
    }
}
