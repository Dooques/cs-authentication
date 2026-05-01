using ConferenceManager.Model;
using ConferenceManager.Model.Models;

namespace ConferenceManager.Service
{
    public interface IEventService
    {
        public Event GetEvent(int id);
        public IEnumerable<Event> GetEvents();
        public Event PostEvent(Event @event);
    }
    public class EventService(IEventModel eventModel) : IEventService
    {
        private readonly IEventModel _eventModel = eventModel;

        public Event GetEvent(int id)
        {
            return _eventModel.FetchEvent(id);
        }

        public IEnumerable<Event> GetEvents()
        {
            return _eventModel.FetchEvents();
        }

        public Event PostEvent(Event @event)
        {
            return _eventModel.InsertEvent(@event);
        }

    }
}
