using ClientManagerMobile.Services;
using ClientManagerMobile.ViewModels;
using ClientManagerMobile.Views;
using Microsoft.Extensions.Logging;

namespace ClientManagerMobile;

public static class MauiProgram
{
    public static IServiceProvider? Services { get; private set; }

    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => { /* ... */ });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<IDialogService, DialogService>();
        builder.Services.AddSingleton<ClientService>();
        builder.Services.AddSingleton<ClientViewModel>();
        builder.Services.AddTransient<ClientPage>();
        builder.Services.AddSingleton<MainPage>();

        var app = builder.Build();

        Services = app.Services;

        return app;
    }
}
