using Swashbuckle.AspNetCore.Annotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace ConferenceManager.Model.Models
{
    public class Event
    {
        [SwaggerIgnore]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName ("title")]
        [JsonRequired]
        public string Title { get; set; }

        [JsonPropertyName("date")]
        [JsonRequired]
        public string Date { get; set; }

        [JsonPropertyName("venue")]
        [JsonRequired]
        public string Venue { get; set; }

        [JsonPropertyName("description")]
        [JsonRequired]
        public string Description { get; set; }

        [JsonPropertyName("category")]
        [JsonRequired]
        public string Category { get; set; }
    }
}
