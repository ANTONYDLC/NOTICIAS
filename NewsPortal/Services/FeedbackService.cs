using System.Net.Http.Json;

public class FeedbackDto
{
    public int FeedbackId { get; set; }
    public bool IsPositive { get; set; }
}

public class FeedbackService
{
    private readonly HttpClient _httpClient;

    public FeedbackService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> SendFeedbackAsync(int feedbackId, bool isPositive)
    {
        var response = await _httpClient.PostAsJsonAsync("api/feedbacks/like", new FeedbackDto
        {
            FeedbackId = feedbackId,
            IsPositive = isPositive
        });

        return response.IsSuccessStatusCode;
    }
}
