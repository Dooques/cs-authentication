using ConferenceManager.Model.Models;
using ConferenceManager.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController(
        IEventService eventService, IAttendeeService attendeeService, ISpeakerService speakerService
    ) : ControllerBase
    {
        private readonly IEventService _eventService = eventService;
        private readonly IAttendeeService _attendeeService = attendeeService;
        private readonly ISpeakerService _speakerService = speakerService;

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

        [Authorize]
        [HttpPost]
        [Route("{eventId}/attendees")]
        public IActionResult PostAttendeeForEvent(int eventId, Attendee attendee)
        {
            Request.Headers.TryGetValue("name", out var nameHeader);
            Request.Headers.TryGetValue("id", out var idHeader);
            Console.WriteLine(nameHeader);
            Console.WriteLine(idHeader);

            attendee.EventId = eventId.ToString();

            var postedAttendee = _attendeeService.PostAttendee(attendee);

            return Created($"/events/{eventId}/attendees/${attendee.Id}", postedAttendee);   
        }

        [Authorize]
        [HttpPost]
        [Route("{eventId}/speakers")]
        public IActionResult PostSpeaker(int eventId, Speaker speaker)
        {
            return Created($"events/{eventId}/speakers/{speaker.Id}", _speakerService.PostSpeaker(speaker));
        }
    }
}
