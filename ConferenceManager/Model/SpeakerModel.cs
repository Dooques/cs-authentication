using ConferenceManager.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManager.Model
{
    public interface ISpeakerModel
    {
        public IEnumerable<Speaker> GetAllSpeakers();
        public Speaker GetSpeaker(int id);
        Speaker PostSpeaker(Speaker speaker);
    }
    public class SpeakerModel: ISpeakerModel
    {
        public IEnumerable<Speaker> SpeakerList = new List<Speaker>();

        public IEnumerable<Speaker> GetAllSpeakers()
        {
            return SpeakerList;
        }

        public Speaker GetSpeaker(int id)
        {
            return SpeakerList.First(a => a.Id == id);
        }

        public Speaker PostSpeaker(Speaker speaker)
        {
            speaker.Id = SpeakerList.Count();
            SpeakerList.ToList().Add(speaker);
            return SpeakerList.ToList().Find(s => s.Id == speaker.Id) ?? 
                throw new ArgumentException("Failed to add Speaker to List");
        }
    }
}
