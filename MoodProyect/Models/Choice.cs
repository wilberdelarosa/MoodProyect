using CommunityToolkit.Mvvm.ComponentModel;

namespace MoodProyect.Models;

public partial class Choice : ObservableObject
{
    public string Text { get; set; } = string.Empty;
    public int Value { get; set; }

    [ObservableProperty]
    bool isSelected;
}
