using ConferenceManager.Model;
using ConferenceManager.Model.Models;

namespace ConferenceManager.Service
{
    public interface IAttendeeService
    {
        public IEnumerable<Attendee> GetAllAttendees();
        public Attendee GetAttendee(string id, string userId);
        public Attendee PostAttendee(Attendee attendee);
    }

    public class AttendeeService(IAttendeeModel attendeeModel) : IAttendeeService
    {
        private readonly IAttendeeModel _attendeeModel = attendeeModel;
        public IEnumerable<Attendee> GetAllAttendees()
        {
            return _attendeeModel.GetAllAttendees();
        }

        public Attendee GetAttendee(string id, string userId)
        {
            return _attendeeModel.GetAttendee(id, userId);
        }

        public Attendee PostAttendee(Attendee attendee)
        {
            return _attendeeModel.PostAttendee(attendee);
        }
    }
}
