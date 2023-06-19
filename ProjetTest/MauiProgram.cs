using Microsoft.Extensions.Logging;
using ProjetTest.Data;

namespace ProjetTest;

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
			});

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

        // Set path to the SQLite database (it will be created if it does not exist)
        var dbPath =
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                @"Translations.db");
        // Register WeatherForecastService and the SQLite database
        builder.Services.AddSingleton<TranslationsService>(
            s => ActivatorUtilities.CreateInstance<TranslationsService>(s, dbPath));

        return builder.Build();
	}
}
