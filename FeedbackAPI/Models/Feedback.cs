using System;

namespace FeedbackAPI.Models
{
    public class Feedback
    {
        public int Id { get; set; } // clave primaria
        public int PostId { get; set; }
        public string Sentimiento { get; set; } = string.Empty; // "like" o "dislike"
        public DateTime Fecha { get; set; }
    }
}
