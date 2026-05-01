using ConferenceManager.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManager.Model
{
    public interface IAttendeeModel
    {
        public IEnumerable<Attendee> GetAllAttendees();
        public Attendee GetAttendee(string id, string userId);
        public Attendee PostAttendee(Attendee attendee);
    }
    public class AttendeeModel : IAttendeeModel
    {
        public List<Attendee> AttendeeList = new List<Attendee>();

        public IEnumerable<Attendee> GetAllAttendees()
        {
            return AttendeeList;
        }

        public Attendee GetAttendee(string id, string userId)
        {
            AttendeeList.ForEach(a => Console.WriteLine($"id: {a.Id}, name: {a.Name}, event: {a.EventId}"));
            Console.WriteLine($"UserId: {userId}");
            if (!AttendeeList.Any(a => a.Id == userId)) throw new ArgumentException($"UserID must match");
            return AttendeeList.First(a => a.Id == id);
        }

        public Attendee PostAttendee(Attendee attendee)
        {
            Console.WriteLine($"Adding Attendee, {attendee.Id} {attendee.Name} {attendee.EventId}");
            AttendeeList.Add(attendee);
            foreach (var item in AttendeeList)
            {
                Console.WriteLine($"id: {item.Id}, name: {item.Name}, event: {item.EventId}");
            }
            var newAttendee = AttendeeList.First(a => a.Id == attendee.Id);
            Console.WriteLine($"Adding Attendee, {newAttendee.Id} {newAttendee.Name} {newAttendee.EventId}");
            if (newAttendee is null) throw new ArgumentException($"Failed to add {attendee.Name}");
            return newAttendee;
        }
    }
}
