using ConferenceManager.Model;
using ConferenceManager.Model.Models;

namespace ConferenceManager.Service
{
    public interface ISpeakerService
    {
        public IEnumerable<Speaker> GetAllSpeakers();
        public Speaker GetSpeaker(int id);
        public Speaker PostSpeaker(Speaker speaker);
    }

    public class SpeakerService(ISpeakerModel SpeakerModel) : ISpeakerService
    {
        private readonly ISpeakerModel _speakerModel = SpeakerModel;
        public IEnumerable<Speaker> GetAllSpeakers()
        {
            return _speakerModel.GetAllSpeakers();
        }

        public Speaker GetSpeaker(int id)
        {
            return _speakerModel.GetSpeaker(id);
        }

        public Speaker PostSpeaker(Speaker speaker)
        {
            return _speakerModel.PostSpeaker(speaker);
        }
    }
}
