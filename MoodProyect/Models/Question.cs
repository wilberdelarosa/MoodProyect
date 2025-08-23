using System.Collections.Generic;

namespace MoodProyect.Models;

public class Question
{
    public string Id { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public bool IsOpen { get; set; }
    public bool AllowsMultiple { get; set; }
    public IReadOnlyList<Choice>? Choices { get; set; }
    public string? Answer { get; set; }
}
