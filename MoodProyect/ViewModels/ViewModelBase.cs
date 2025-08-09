using CommunityToolkit.Mvvm.ComponentModel;

namespace MoodProyect.ViewModels;

public partial class ViewModelBase : ObservableObject
{
    [ObservableProperty]
    bool isBusy;

    public virtual void OnAppearing() { }
    public virtual void OnDisappearing() { }
}
