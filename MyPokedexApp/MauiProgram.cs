using Microsoft.Extensions.DependencyInjection;
using MyPokedexApp.Services;

namespace MyPokedexApp;

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
        // Add transient depency injection
        //builder.Services.AddTransient<PokeService>();
        // Add singleton för att det kan finnas en bugg i http socket om man skapar nya http clients
		//builder.Services.AddSingleton<HttpService>();
		return builder.Build();
	}
}
