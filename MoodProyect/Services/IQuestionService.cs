using MoodProyect.Models;

namespace MoodProyect.Services;

public interface IQuestionService
{
    Task<IReadOnlyList<Question>> GetQuestionsAsync();
}
