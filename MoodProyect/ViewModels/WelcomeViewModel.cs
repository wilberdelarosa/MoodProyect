using CommunityToolkit.Mvvm.Input;

namespace MoodProyect.ViewModels;

public partial class WelcomeViewModel : ViewModelBase
{
    [RelayCommand]
    private Task Start() => Shell.Current.GoToAsync("quiz");
}
