using System.Text.Json.Serialization;

namespace book_api.Models
{
    public class Book
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }
    }
}
