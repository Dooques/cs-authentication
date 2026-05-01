using System.Text.Json.Serialization;

namespace ConferenceManager.Model.Models
{
    public class Speaker
    {
        [JsonPropertyName("id")]
        int Id { get; set; }
        
        [JsonPropertyName("name")]
        string Name { get; set; }

        int EventId { get; set; }
    }
}
