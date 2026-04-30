using ConferenceManager.Model;
using ConferenceManager.Model.Models;

namespace ConferenceManager.Service
{
    public interface IEventService
    {
        public Event GetEvent(int id);
        public List<Event> GetEvents();
    }
    public class EventService(IEventModel eventModel) : IEventService
    {
        private readonly IEventModel _eventModel = eventModel;

        public Event GetEvent(int id)
        {
            return _eventModel.FetchEvent(id);
        }

        public List<Event> GetEvents()
        {
            return _eventModel.FetchEvents();
        }

    }
}
