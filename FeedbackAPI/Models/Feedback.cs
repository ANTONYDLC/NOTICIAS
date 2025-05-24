using System;

namespace FeedbackAPI.Models
{
public class Feedback
{
    public int Id { get; set; }
    public string Sentimiento { get; set; }

    public int LikesCount { get; set; } = 0;      // <-- Agregado
    public int DislikesCount { get; set; } = 0;   // <-- Agregado
}

}
