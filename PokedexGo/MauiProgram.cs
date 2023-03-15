using Microsoft.Extensions.Configuration;
using PokedexGo.Models;
using PokedexGo.Services;
using PokedexGo.Settings;
using PokedexGo.ViewModels;
using PokedexGo.Views;
using System.Reflection;

namespace PokedexGo;

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

        // TODO: NEW Gå igenom kommentarer
        // Skapar en configuration för att enklare kunna använda databas options när jag ska connecta med min databas på MongoDB, connectionsträngen samt databasnamn och collectionnamn.
        // På detta sätt behöver jag endast ändra i appsettings.json
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream("PokedexGo.appsettings.json");
        var config = new ConfigurationBuilder()
            .AddJsonStream(stream)
            .Build();
        builder.Configuration.AddConfiguration(config);

        builder.Services.Configure<UserDatabaseSettings>(builder.Configuration.GetSection("UserDatabase"));

        // Adderar Singleton Dependency Injection för de klasser som endast ska instansieras en gång och sparas i minnet
        // Valde att ha det på User för att när man är inloggad så ska samma instans av User och dess property användas på alla sidor
        // Valde att ha det på PokeService
        // Adderar en Transient Dependency Injection för de klasser som ska skapas upp endast när de används och sedan "skrotas"
        // Valde att ha det på UserService för att det inte behövs en och samma instans av det objektet, dvs. behöver inte ta upp minne förutom när man behöver göra ett anrop till databasen
        
        // Services - Singleton
        builder.Services.AddSingleton<PokeService>();
        builder.Services.AddSingleton<AlertService>();
        // Services - Transient
        builder.Services.AddTransient<UserService>();

        // Models - Singleton
        builder.Services.AddSingleton<User>();

        // Views - Transient
        builder.Services.AddTransient<MyPokemonPage>();
        builder.Services.AddTransient<PokemonDetailsPage>();
        builder.Services.AddTransient<ShowMyPokemonPage>();
        builder.Services.AddTransient<CatchEmAllPage>();

        // View Models - Transient
        builder.Services.AddTransient<MyPokemonPageViewModel>();
        builder.Services.AddTransient<ShowMyPokemonPageViewModel>();
        builder.Services.AddTransient<PokemonDetailsPageViewModel>();
        builder.Services.AddTransient<CatchEmAllPageViewModel>();

        return builder.Build();
    }
}