using MoodProyect.Models;

namespace MoodProyect.Services;

public class QuestionService : IQuestionService
{
    public Task<IReadOnlyList<Question>> GetQuestionsAsync()
    {
        var questions = new List<Question>
        {
            new()
            {
                Id = "1",
                Text = "¿Cómo te sientes ahora?",
                IsOpen = false,
                Choices = new List<Choice>
                {
                    new() { Text = "Bien", Value = 2 },
                    new() { Text = "Normal", Value = 1 },
                    new() { Text = "Mal", Value = 0 }
                }
            },
            new()
            {
                Id = "2",
                Text = "¿Cómo ha sido tu nivel de energía hoy?",
                IsOpen = false,
                Choices = new List<Choice>
                {
                    new() { Text = "Alta", Value = 2 },
                    new() { Text = "Media", Value = 1 },
                    new() { Text = "Baja", Value = 0 }
                }
            },
            new() { Id = "3", Text = "¿Qué te ha alegrado recientemente?", IsOpen = true },
            new() { Id = "4", Text = "¿Qué te preocupa actualmente?", IsOpen = true },
            new() { Id = "5", Text = "¿Qué objetivo te gustaría lograr mañana?", IsOpen = true }
        };

        return Task.FromResult<IReadOnlyList<Question>>(questions);
    }
}
