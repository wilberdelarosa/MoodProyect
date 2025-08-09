using MoodProyect.ViewModels;

namespace MoodProyect.Views;

public partial class ResultPage : ContentPage
{
    public ResultPage(ResultViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
