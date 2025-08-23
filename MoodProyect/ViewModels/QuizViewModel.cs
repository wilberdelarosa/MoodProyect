using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MoodProyect.Models;
using MoodProyect.Services;
using System.Collections.ObjectModel;
using System.Linq;

namespace MoodProyect.ViewModels;

public partial class QuizViewModel : ViewModelBase
{
    private readonly IQuestionService _questionService;
    private readonly IGroqService _groqService;

    public ObservableCollection<Question> Questions { get; } = new();

    [ObservableProperty]
    int currentIndex;

    [ObservableProperty]
    string? openAnswer;

    public Question? CurrentQuestion => CurrentIndex >= 0 && CurrentIndex < Questions.Count ? Questions[CurrentIndex] : null;
    public double Progress => Questions.Count == 0 ? 0 : (CurrentIndex + 1) / (double)Questions.Count;

    public QuizViewModel(IQuestionService questionService, IGroqService groqService)
    {
        _questionService = questionService;
        _groqService = groqService;
    }

    public override async void OnAppearing()
    {
        if (Questions.Count == 0)
        {
            var items = await _questionService.GetQuestionsAsync();
            foreach (var q in items)
                Questions.Add(q);
            CurrentIndex = 0;
        }
    }

    partial void OnCurrentIndexChanged(int value)
    {
        OpenAnswer = CurrentQuestion?.Answer;
    }

    [RelayCommand]
    void SelectChoice(Choice choice)
    {
        if (CurrentQuestion?.Choices == null)
            return;

        if (CurrentQuestion.AllowsMultiple)
        {
            choice.IsSelected = !choice.IsSelected;
            CurrentQuestion.Answer = string.Join(", ", CurrentQuestion.Choices
                .Where(c => c.IsSelected)
                .Select(c => c.Text));
        }
        else
        {
            foreach (var c in CurrentQuestion.Choices)
                c.IsSelected = false;
            choice.IsSelected = true;
            CurrentQuestion.Answer = choice.Text;
        }
    }

    [RelayCommand]
    void Next()
    {
        if (CurrentQuestion != null && CurrentQuestion.IsOpen)
            CurrentQuestion.Answer = OpenAnswer;
        if (CurrentIndex < Questions.Count - 1)
            CurrentIndex++;
    }

    [RelayCommand]
    void Prev()
    {
        if (CurrentQuestion != null && CurrentQuestion.IsOpen)
            CurrentQuestion.Answer = OpenAnswer;
        if (CurrentIndex > 0)
            CurrentIndex--;
    }

    [RelayCommand]
    async Task Finish()
    {
        if (CurrentQuestion != null && CurrentQuestion.IsOpen)
            CurrentQuestion.Answer = OpenAnswer;

        var session = new QuizSession();
        foreach (var q in Questions)
            session.Answers[q.Text] = q.Answer ?? string.Empty;

        IsBusy = true;
        var result = await _groqService.GetAdviceAsync(session);
        IsBusy = false;

        var parameters = new Dictionary<string, object>
        {
            { "Advice", result.Advice },
            { "Closing", result.ClosingPhrase }
        };
        await Shell.Current.GoToAsync("result", parameters);
    }
}
