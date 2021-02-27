using System;
using System.Text.Json.Serialization;

namespace book_api.Models
{
    public class Loan
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("BookId")]
        public int BookId { get; set; }
        [JsonPropertyName("borrowed")]
        public DateTime Borrowed { get; set; }

        [JsonPropertyName("returned")]
        public DateTime? Returned { get; set; }
    }
}
