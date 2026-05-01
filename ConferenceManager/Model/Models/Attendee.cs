using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace ConferenceManager.Model.Models
{
    public class Attendee
    {
        [SwaggerIgnore]
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [SwaggerIgnore]
        [JsonPropertyName("eventId")]
        public string EventId { get; set; } = "";
    }
}
