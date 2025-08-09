using MoodProyect.ViewModels;

namespace MoodProyect.Views;

public partial class WelcomePage : ContentPage
{
    public WelcomePage(WelcomeViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
