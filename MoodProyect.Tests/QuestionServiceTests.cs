using Xunit;
using MoodProyect.Services;

namespace MoodProyect.Tests;

public class QuestionServiceTests
{
    [Fact]
    public async Task ReturnsFiveQuestions()
    {
        var service = new QuestionService();
        var questions = await service.GetQuestionsAsync();
        Assert.Equal(5, questions.Count);
    }
}
