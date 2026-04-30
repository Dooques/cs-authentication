using ConferenceManager.Model.Models;
using System.Text.Json;

namespace ConferenceManager.Model
{
    public interface IEventModel
    {
        public List<Event> FetchEvents();
        public Event FetchEvent(int id);
    }

    public class EventModel : IEventModel
    {
        public Event FetchEvent(int id)
        {
            string? jsonBody = File.ReadAllText("Resources\\EventData.json");
            List<Event> eventList = JsonSerializer.Deserialize<List<Event>>(jsonBody) ?? new();

            if (eventList.Count > 0)
                return eventList.Where(e => e.Id == id).First();
            else
                throw new ArgumentException("This event id does not exist");
        }

        public List<Event> FetchEvents()
        {
            string? jsonBody = File.ReadAllText("Resources\\EventData.json");
            List<Event> eventList = JsonSerializer.Deserialize<List<Event>>(jsonBody) ?? new();

            if (eventList.Count > 0) 
                return eventList;
            else 
                throw new ArgumentException("EventData contains no Events");
        }
    }
}
