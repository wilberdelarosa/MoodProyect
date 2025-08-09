using MoodProyect.Models;

namespace MoodProyect.Services;

public interface IGroqService
{
    Task<GroqResult> GetAdviceAsync(QuizSession session);
}
