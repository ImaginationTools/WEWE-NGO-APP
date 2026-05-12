using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WEWE.Maui.Services;
using WEWE.Maui.ViewModels;

namespace WEWE.Maui;

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

        // =========================
        // REGISTER SERVICES (IMPORTANT)
        // =========================

        //builder.Services.AddSingleton<DatabaseService>();
        builder.Services.AddSingleton<DatabaseService>();
        // REGISTER VIEWMODELS
        // =========================

        builder.Services.AddSingleton<WidowRegistrationViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}