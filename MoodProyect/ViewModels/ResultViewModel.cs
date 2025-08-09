using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;

namespace MoodProyect.ViewModels;

public partial class ResultViewModel : ViewModelBase, IQueryAttributable
{
    [ObservableProperty]
    string advice = string.Empty;

    [ObservableProperty]
    string closingPhrase = string.Empty;

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("Advice", out var a))
            Advice = a?.ToString() ?? string.Empty;
        if (query.TryGetValue("Closing", out var c))
            ClosingPhrase = c?.ToString() ?? string.Empty;
    }

    [RelayCommand]
    Task Retry() => Shell.Current.GoToAsync("//welcome");
}
