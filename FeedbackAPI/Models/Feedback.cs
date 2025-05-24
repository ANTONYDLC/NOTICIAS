using System;

namespace FeedbackAPI.Models
{
    public class Feedback
    {
        public int Id { get; set; }  // PK autoincremental
        public int PostId { get; set; }
        public string Sentimiento { get; set; } = string.Empty;

        public DateTime Fecha { get; set; }
    }
}
