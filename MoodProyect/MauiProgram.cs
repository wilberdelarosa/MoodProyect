using Microsoft.Extensions.Logging;
using MoodProyect.Services;
using MoodProyect.ViewModels;
using MoodProyect.Views;

namespace MoodProyect
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<IQuestionService, QuestionService>();
            builder.Services.AddHttpClient<IGroqService, GroqService>();

            builder.Services.AddTransient<WelcomeViewModel>();
            builder.Services.AddTransient<QuizViewModel>();
            builder.Services.AddTransient<ResultViewModel>();

            builder.Services.AddTransient<WelcomePage>();
            builder.Services.AddTransient<QuizPage>();
            builder.Services.AddTransient<ResultPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
