using ConferenceManager.Model.Models;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.Tracing;
using System.Text.Json;

namespace ConferenceManager.Model
{
    public interface IEventModel
    {
        public IEnumerable<Event> FetchEvents();
        public Event FetchEvent(int id);
        public Event InsertEvent(Event @event);
    }

    public class EventModel : IEventModel
    {
        private List<Event> _eventList = new();

        public EventModel()
        {
            string? jsonBody = File.ReadAllText("Resources\\EventData.json");
            _eventList = JsonSerializer.Deserialize<List<Event>>(jsonBody) ?? new();

        }
        public Event FetchEvent(int id)
        {
            return _eventList.Where(e => e.Id == id).First() ?? throw new ArgumentException("This event id does not exist");    
        }

        public IEnumerable<Event> FetchEvents()
        {
            if (_eventList.Count is 0) throw new ArgumentException("EventData contains no Events");

            return _eventList;
        }

        public Event InsertEvent(Event @event)
        {
            @event.Id = _eventList.Count + 1;
            _eventList.Add(@event);
            return @event;
        }
    }
}
