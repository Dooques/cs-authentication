using ConferenceManager.Model.Models;
using ConferenceManager.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController(IEventService eventService) : ControllerBase
    {
        private readonly IEventService _eventService = eventService;

        [HttpGet]
        public IActionResult GetEvents()
        {
            return Ok(_eventService.GetEvents());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEventById(int id)
        {
            return Ok(_eventService.GetEvent(id));
        }

        [Authorize]
        [HttpPost]
        public IActionResult PostEvent(Event eventObject)
        {   
            Event postedEvent = _eventService.PostEvent(eventObject);
            return Created($"/events/${postedEvent.Id}", postedEvent);
        }
    }
}
