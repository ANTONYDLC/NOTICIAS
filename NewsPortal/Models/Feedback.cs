namespace NewsPortal.Models
{
    public class Feedback
    {
        public int PostId { get; set; }
        public string Sentimiento { get; set; }
        public DateTime Fecha { get; set; }
    }
}
