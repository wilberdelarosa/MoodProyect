using MoodProyect.Models;
using MoodProyect.Services;
using Xunit;

namespace MoodProyect.Tests;

public class GroqServiceTests
{
    [Fact]
    public async Task ReturnsFallbackWithoutApiKey()
    {
        Environment.SetEnvironmentVariable("GROQ_API_KEY", null);
        var service = new GroqService(new HttpClient());
        var result = await service.GetAdviceAsync(new QuizSession());
        Assert.Contains("API key", result.Advice);
    }
}
