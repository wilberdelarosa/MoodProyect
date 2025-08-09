using System.Collections.Generic;

namespace MoodProyect.Models;

public class QuizSession
{
    public Dictionary<string, string> Answers { get; set; } = new();
}
