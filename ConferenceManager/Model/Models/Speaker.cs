using System.Text.Json.Serialization;

namespace ConferenceManager.Model.Models
{
    public class Speaker
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("eventId")]
        public int EventId { get; set; }
    }
}
