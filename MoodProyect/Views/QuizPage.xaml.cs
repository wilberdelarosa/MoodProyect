using Microsoft.Maui.Controls;
using MoodProyect.ViewModels;

namespace MoodProyect.Views
{
    public partial class QuizPage : ContentPage
    {
        public QuizPage(QuizViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is ViewModelBase vm)
                vm.OnAppearing();
        }
    }
}
