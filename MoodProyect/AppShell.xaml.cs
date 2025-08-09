namespace MoodProyect
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("quiz", typeof(Views.QuizPage));
            Routing.RegisterRoute("result", typeof(Views.ResultPage));
        }
    }
}
